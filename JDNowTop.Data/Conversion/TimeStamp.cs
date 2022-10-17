using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDNowTop.Data.Conversion
{
    public static class TimeStamp
    {
        private static readonly DateTime _epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static DateTime GetDate(int stamp)
        {
            var date = _epoch.AddSeconds(stamp);
            return date;
        }

        public static int GetTimeStamp(DateTime time)
        {
            var epochSpan = time - _epoch;
            return (int)epochSpan.TotalSeconds;
        }
    }
}
