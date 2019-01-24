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

    //public class SymQuote
    //{
    //    public string symbol { get; set; }
    //    public string companyName { get; set; }
    //    public string primaryExchange { get; set; }
    //    public string sector { get; set; }
    //    public string calculationPrice { get; set; }
    //    public double open { get; set; }
    //    public long openTime { get; set; }
    //    public double close { get; set; }
    //    public long closeTime { get; set; }
    //    public double high { get; set; }
    //    public double low { get; set; }
    //    public double latestPrice { get; set; }
    //    public string latestSource { get; set; }
    //    public string latestTime { get; set; }
    //    public long latestUpdate { get; set; }
    //    public int latestVolume { get; set; }
    //    public double iexRealtimePrice { get; set; }
    //    public int iexRealtimeSize { get; set; }
    //    public long iexLastUpdated { get; set; }
    //    public double delayedPrice { get; set; }
    //    public long delayedPriceTime { get; set; }
    //    public double extendedPrice { get; set; }
    //    public double extendedChange { get; set; }
    //    public double extendedChangePercent { get; set; }
    //    public long extendedPriceTime { get; set; }
    //    public double previousClose { get; set; }
    //    public double change { get; set; }
    //    public double changePercent { get; set; }
    //    public double iexMarketPercent { get; set; }
    //    public int iexVolume { get; set; }
    //    public int avgTotalVolume { get; set; }
    //    public int iexBidPrice { get; set; }
    //    public int iexBidSize { get; set; }
    //    public int iexAskPrice { get; set; }
    //    public int iexAskSize { get; set; }
    //    public long marketCap { get; set; }
    //    public double peRatio { get; set; }
    //    public double week52High { get; set; }
    //    public int week52Low { get; set; }
    //    public double ytdChange { get; set; }
    //}

    class Program
    {
        static void Main(string[] args)
        {
            var json = File.ReadAllText(@"C:\Users\jc\Desktop\JSN.json");
            var jsonObj = JObject.Parse(json);
            var jsonProps = jsonObj.Properties();

            var quoteList = jsonProps
                .Select(x => x.Value.ToObject<Quote>())
                .Select(x => x.quote).ToList();

            using (var ctx = new stockrDb()) {
                ctx.Quote_stag.AddRange(quoteList);
                ctx.SaveChanges();
            }

            //foreach (var prop in jsonProps)
            //{
            //    var name = prop.Name;
            //    var quoteOuter = prop.Value.ToObject<Quote>();
            //    quoteList.Add(quoteOuter.quote);
            //}




            //List<vSymbols> symb;
            //List<vSymbols> symbSegment;

            //List<string> quoteUrls = new List<string>();

            //using (var ctx = new stockrDb())
            //{
            //    symb = ctx.vSymbols.Where(x => x.SymbolType == "cs" && x.isEnabled == true).ToList();
            //}

            //while (symb.Any())
            //{
            //    symbSegment = symb.Take(175).ToList();
            //    symb = symb.Except(symbSegment).ToList();

            //    var url = @"https://api.iextrading.com/1.0/stock/market/batch?symbols={0}&types=quote";
            //    var symbolCsv = string.Join(",", symbSegment.Select(x => x.Symbol).ToArray());

            //    quoteUrls.Add(string.Format(url, symbolCsv));
            //}

            //using (WebClient wc = new WebClient())
            //{
            //    foreach (var url in quoteUrls)
            //    {
            //        var dtNow = DateTime.Now;
            //        var jsonStr = wc.DownloadString(url);
            //    }
            //}
        }
    }
}
