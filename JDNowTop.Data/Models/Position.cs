using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JDNowTop.Data.Models
{
    public class Position
    {
        public int Id { get; set; }
        public int WeekId { get; set; }
        public Week Week { get; set; }
        public int Pos { get; set; }
        public Song Song { get; set; }
        public string MapName { get; set; }
        public int Delta { get; set; }
    }
}
