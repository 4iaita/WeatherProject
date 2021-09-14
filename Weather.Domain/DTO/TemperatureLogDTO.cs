using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Domain.DTO
{
   public  class TemperatureLogDTO
    {
        public string Id { set; get; }
        public int Temperature { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsArchived { get; set; }
        public string WeatherConditionId { get; set; }
    }
}
