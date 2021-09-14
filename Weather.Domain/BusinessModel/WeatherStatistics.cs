using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weather.Domain.DTO;

namespace Weather.Domain.BusinessModel
{
    public class WeatherStatistics
    {
        private WeatherConditionDTO weatherCondition;
        private List<int> temperatureList;

        public WeatherStatistics(WeatherConditionDTO weatherCondition, List<int> temperatureList)
        {
            this.weatherCondition = weatherCondition;
            this.temperatureList = temperatureList;
        }

        public void SetStatistics()
        {
            weatherCondition.MinTemperature = temperatureList.Min();
            weatherCondition.MaxTemperature = temperatureList.Max();
            weatherCondition.AverageTemperature = (int)temperatureList.Average();
        }
    }
}
