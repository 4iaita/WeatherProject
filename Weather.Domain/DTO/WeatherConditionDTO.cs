using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Domain.DTO
{
    public class WeatherConditionDTO
    {
        public string Id { set; get; }
        public int CurrentTemperature { get; set; }
        public int AverageTemperature { get; set; }
        public int MaxTemperature { get; set; }
        public int MinTemperature { get; set; }
        public string CityId { get; set; }
    }
}
