using System;
using System.Collections.Generic;
using System.Text;
using Weather.Data.EF;
using Weather.Data.Interfaces;

namespace Weather.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
            TemperatureLog = new TemperatureLogRepository(_context);
            WeatherCondition = new WeatherConditionRepository(_context);
            City = new CityRepository(_context);
        }
        public ITemperatureLogRepository TemperatureLog { get; private set; }
        public IWeatherConditionRepository WeatherCondition { get; private set; }
        public ICityRepository City { get; private set; }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
