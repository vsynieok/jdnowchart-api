using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDNowTop.Data.Models.DTO
{
    public class PositionDto
    {
        public int? Id { get; set; }
        public string MapName { get; set; }
        public int WeekId { get; set; }
        public int Pos { get; set; }
        public int Delta { get; set; }
    }
}
