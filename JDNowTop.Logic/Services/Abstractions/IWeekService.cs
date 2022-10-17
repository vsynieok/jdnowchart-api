using JDNowTop.Data.Models;
using JDNowTop.Data.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDNowTop.Logic.Services.Abstractions
{
    public interface IWeekService : IService<Week>
    {
        Task<bool> DeleteAsync(int _id);
        Task<Week?> GetAsync(int _id);
        Task<Week?> UpdateAsync(Week _entity, int _id);
    }
}
