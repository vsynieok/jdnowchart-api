using AutoMapper;
using JDNowTop.Data.Conversion;
using JDNowTop.Data.Models;
using JDNowTop.Data.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDNowTop.Data.DataMaps
{
    public class WeekProfile : Profile
    {
        
        public WeekProfile()
        {
            CreateMap<Week, WeekDto>()
                .ForMember(
                    dto => dto.Positions,
                    options => options.MapFrom(entity => entity.Positions ?? new List<Position>())
                    )
                .ForMember(
                    dto => dto.UpdatedAt,
                    options => options.MapFrom(entity => TimeStamp.GetTimeStamp(entity.UpdatedAt))
                    );

            CreateMap<WeekDto, Week>()
                .ForMember(
                    entity => entity.UpdatedAt,
                    options => options.MapFrom(dto => TimeStamp.GetDate(dto.UpdatedAt))
                    );
        }
    }
}
