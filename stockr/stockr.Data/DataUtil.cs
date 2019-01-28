using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stockr.Data
{
    public static class DataUtil
    {
        public static void Log(string msg) {
            using (var ctx = new stockrDb()) {
                ctx.Log.Add(new Log {
                    SystemTime = DateTime.Now,
                    DateModified = DateTime.Now,
                    Msg = msg
                });
                ctx.SaveChanges();
            }
        }
    }
}
