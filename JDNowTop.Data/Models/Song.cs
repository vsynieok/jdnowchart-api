using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDNowTop.Data.Models
{
    public class Song
    {
        public string MapName { get; set; }

        public int Mode { get; set; }
        public int GameVersion { get; set; }
        public int TotalPlays { get; set; }

        public ICollection<Position> Positions { get; set; }
    }
}
