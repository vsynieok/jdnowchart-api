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
    internal class PositionProfile : Profile
    {
        public PositionProfile()
        {
            CreateMap<Position, PositionDto>()
                .ReverseMap();
        }
    }
}
