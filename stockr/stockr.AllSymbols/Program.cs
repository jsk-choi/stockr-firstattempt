using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

using Newtonsoft;

using stockr.Data;

namespace stockr.AllSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            DataUtil.Log($"Symbol load start");

            using (WebClient wc = new WebClient())
            {
                var jsonStr = wc.DownloadString("https://api.iextrading.com/1.0/ref-data/symbols");
                var symbolJson = Newtonsoft.Json.JsonConvert.DeserializeObject<IList<Symbol>>(jsonStr);
                var dtNow = DateTime.Now;

                var efSymbols = symbolJson.Select(x => new Symbols
                {
                    iexId = Convert.ToInt32(x.iexId),
                    Symbol = x.symbol,
                    SymbolName = x.name,
                    isEnabled = x.isEnabled,
                    SymbolType = x.type,
                    DateModified = dtNow
                });

                using (var ctx = new stockrDb())
                {
                    if (efSymbols.Any())
                    {
                        ctx.Symbols.AddRange(efSymbols);
                        ctx.SaveChanges();

                        ctx.Database.ExecuteSqlCommand("exec dbo.spSymbolsConsolidation");
                    }
                }

                DataUtil.Log($"Symbol load end - {efSymbols.Count()}");
            }
        }
    }

    public class Symbol
    {
        public string symbol { get; set; }
        public string name { get; set; }
        public string date { get; set; }
        public bool isEnabled { get; set; }
        public string type { get; set; }
        public string iexId { get; set; }
    }
}
