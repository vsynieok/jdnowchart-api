using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDNowTop.Logic.Services.Abstractions
{
    public interface ITimeService
    {
        int GetTimeStamp(DateTime time);
        DateTime GetDate(int stamp);
    }
}
