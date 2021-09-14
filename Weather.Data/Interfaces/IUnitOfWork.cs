using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ITemperatureLogRepository TemperatureLog { get; }
        IWeatherConditionRepository WeatherCondition { get; }
        ICityRepository City { get; }
    }
}
