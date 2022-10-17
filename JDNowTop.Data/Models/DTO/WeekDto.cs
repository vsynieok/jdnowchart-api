using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDNowTop.Data.Models.DTO
{
    public class WeekDto
    {
        public int? Id { get; set; }
        public int UpdatedAt { get; set; }
        public IEnumerable<Position>? Positions { get; set; }
    }
}
