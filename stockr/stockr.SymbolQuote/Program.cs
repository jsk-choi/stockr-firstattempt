using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using stockr.Data;

namespace stockr.SymbolQuote
{
    public class Quote {
        public Quote_stag quote { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var timeUtc = DateTime.UtcNow;
            TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime estTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, easternZone);

            var marketOpen = false;

            using (var ctx = new stockrDb()) {
                marketOpen = ctx.MarketOpen.Where(x => x.DtOpen <= estTime && x.DtClose >= estTime).Any();
            }

            DataUtil.Log($"Quote load - marketOpen: {marketOpen}");

            if (!marketOpen) return;

            DataUtil.Log($"Quote load start");

            List<vSymbols> symb;
            List<vSymbols> symbSegment;

            List<string> quoteUrls = new List<string>();

            using (var ctx = new stockrDb())
            {
                symb = ctx.vSymbols.Where(x => x.SymbolType.ToLower().Trim() == "cs" && x.isEnabled == true).ToList();
            }

            while (symb.Any())
            {
                symbSegment = symb.Take(150).ToList();
                symb = symb.Except(symbSegment).ToList();

                var url = @"https://api.iextrading.com/1.0/stock/market/batch?symbols={0}&types=quote";
                var symbolCsv = string.Join(",", symbSegment.Select(x => x.Symbol).ToArray());

                quoteUrls.Add(string.Format(url, symbolCsv));
            }

            DataUtil.Log($"Quote load segments: {quoteUrls.Count()}");

            using (WebClient wc = new WebClient())
            {
                int ctr = 0;
                foreach (var url in quoteUrls)
                {
                    ctr++;

                    var dtNow = DateTime.Now;
                    var jsonStr = wc.DownloadString(url);
                    var jsonObj = JObject.Parse(jsonStr);
                    var jsonProps = jsonObj.Properties();

                    var quoteList = jsonProps
                        .Select(x => x.Value.ToObject<Quote>())
                        .Select(x => x.quote)
                        .Select(c =>
                        {
                            c.SystemTime = dtNow;
                            return c;
                        })
                        .ToList();

                    try
                    {
                        using (var ctx = new stockrDb())
                        {
                            ctx.Quote_stag.AddRange(quoteList);
                            ctx.SaveChanges();

                            ctx.Database.ExecuteSqlCommand("exec dbo.spSymbolsExtendedConsolidation");
                            ctx.Database.ExecuteSqlCommand("exec dbo.spQuotesConsolidation");
                        }
                    }
                    catch (Exception ex)
                    {
                        DataUtil.Log($"Quote load error: {ex.InnerException.InnerException.Message}");
                    }

                    DataUtil.Log($"Quote load segments: {ctr}-{quoteUrls.Count()}");
                }
            }

            using (var ctx = new stockrDb())
            {
            }

            DataUtil.Log($"Quote load done");
        }
    }
}
