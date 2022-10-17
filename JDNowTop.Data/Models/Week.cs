using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDNowTop.Data.Models
{
    public class Week
    {
        public int Id { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<Position> Positions { get; set; }
    }
}
