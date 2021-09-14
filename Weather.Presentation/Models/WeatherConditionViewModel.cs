using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weather.Presentation.Models
{
    public class WeatherConditionViewModel
    {
        public int CurrentTemperature { get; set; }
        public int AverageTemperature { get; set; }
        public int MaxTemperature { get; set; }
        public int MinTemperature { get; set; }
        public double AverageTemperatureF { get; set; }
        public double MaxTemperatureF { get; set; }
        public double MinTemperatureF { get; set; }
        public double AverageTemperatureK { get; set; }
        public double MaxTemperatureK { get; set; }
        public double MinTemperatureK { get; set; }

       
        
        public void SetWeatherUnitOfMeasure()
        {
            AverageTemperatureF = Fahrenheit(AverageTemperature);
            MaxTemperatureF = Fahrenheit(MaxTemperature);
            MinTemperatureF = Fahrenheit(MinTemperature);

            AverageTemperatureK = Kelvin(AverageTemperature);
            MaxTemperatureK = Kelvin(MaxTemperature);
            MinTemperatureK = Kelvin(MinTemperature);
        }

        public double Kelvin(int value)
        {
            return value + 273.15;
        }
        public double Fahrenheit(int value)
        {
            return (value * 1.8) + 32;
        }
    }
}
