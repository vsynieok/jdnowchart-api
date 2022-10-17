using AutoMapper;
using JDNowTop.Data.Models;
using JDNowTop.Data.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDNowTop.Data.DataMaps
{
    internal class SongProfile : Profile
    {
        public SongProfile()
        {
            CreateMap<Song, SongDto>()
                .ReverseMap();
        }
    }
}
