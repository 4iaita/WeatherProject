using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Data.Entities
{
    public class TemperatureLog:BaseEntity
    {
        public int Temperature { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsArchived { get; set; }
        public WeatherCondition WeatherCondition { get; set; }
        public string WeatherConditionId { get; set; }
    }
}
