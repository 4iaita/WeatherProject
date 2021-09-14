using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weather.Data.EF;
using Weather.Data.Entities;
using Weather.Data.Interfaces;

namespace Weather.Data.Repositories
{
    public class TemperatureLogRepository : GenericRepository<TemperatureLog>, ITemperatureLogRepository
    {
        public TemperatureLogRepository(DatabaseContext context) : base(context)
        {
        }

        public List<int> GetTemperatureByWeatherConditionId(string id)
        {
            return _dbContext.TemperatureLog.Where(tl => tl.WeatherConditionId == id && tl.IsArchived==false).Select(t => t.Temperature).ToList();
        }

        public TemperatureLog GetTemperatureLogByCityIdAndDate(string cityId, DateTime date)
        {
            return _dbContext.TemperatureLog.Where(tl => tl.DateTime == date &&
            tl.WeatherConditionId == _dbContext.WeatherCondition
            .Where(wc => wc.CityId == cityId).Select(i => i.Id).FirstOrDefault().ToString()).FirstOrDefault();
        }

        public List<TemperatureLog> GetTemperatureLogListByCityId(string cityId)
        {
            return _dbContext.TemperatureLog.Where(tl => tl.WeatherConditionId ==
            _dbContext.WeatherCondition.Where(wc => wc.CityId == cityId).Select(i => i.Id).FirstOrDefault().ToString())
                .OrderBy(tl => tl.DateTime).ToList();
        }

        public List<TemperatureLog> GetTemperatureLogListByCityIdAndDates(string cityId, DateTime dateStart, DateTime dateFinish)
        {
            return _dbContext.TemperatureLog.Where(tl => tl.WeatherConditionId ==
            _dbContext.WeatherCondition.Where(wc => wc.CityId == cityId ).Select(i => i.Id).FirstOrDefault().ToString() &&
            (tl.DateTime >= dateStart && tl.DateTime <=dateFinish))
                .OrderBy(tl => tl.DateTime).ToList();
        }
    }
}
