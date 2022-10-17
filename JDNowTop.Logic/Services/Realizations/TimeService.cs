using JDNowTop.Data.Conversion;
using JDNowTop.Logic.Services.Abstractions;

namespace JDNowTop.Logic.Services.Realizations
{
    public class TimeService : ITimeService
    {
        public DateTime GetDate(int stamp) => TimeStamp.GetDate(stamp);
        public int GetTimeStamp(DateTime time) => TimeStamp.GetTimeStamp(time);
    }
}
