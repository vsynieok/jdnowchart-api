using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDNowTop.Data.Models.DTO
{
    public class SongDto
    {
        public string MapName { get; set; }
        public int Mode { get; set; }
        public int GameVersion { get; set; }
        public IEnumerable<PositionDto> Positions { get; set; }
    }
}
