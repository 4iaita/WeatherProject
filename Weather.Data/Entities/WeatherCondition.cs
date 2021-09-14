using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Weather.Data.Entities
{
    public class WeatherCondition : BaseEntity
    {
        public int CurrentTemperature { get; set; }
        [NotMapped]
        public int AverageTemperature { get; set; }
        [NotMapped]
        public int MaxTemperature { get; set; }
        [NotMapped]
        public int MinTemperature { get; set; }
        public City City { get; set; }
        public string CityId{get;set;}
    }
}
