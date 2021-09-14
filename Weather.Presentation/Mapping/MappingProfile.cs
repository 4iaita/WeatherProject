using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather.Data.Entities;
using Weather.Domain.DTO;
using Weather.Presentation.Models;

namespace Weather.Presentation.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<City, CityDTO>();
            CreateMap<CityDTO,City>();
            CreateMap<TemperatureLog, TemperatureLogDTO>();
            CreateMap<TemperatureLogDTO,TemperatureLog>();
            CreateMap<WeatherCondition, WeatherConditionDTO>();
            CreateMap<WeatherConditionDTO,WeatherCondition>();
            CreateMap<WeatherConditionViewModel, WeatherConditionDTO>();
            CreateMap<WeatherConditionDTO, WeatherConditionViewModel>();
            
        }

    }
}
