using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weather.Data.EF;
using Weather.Data.Entities;
using Weather.Data.Interfaces;

namespace Weather.Data.Repositories
{
    public class WeatherConditionRepository : GenericRepository<WeatherCondition>, IWeatherConditionRepository
    {
        public WeatherConditionRepository(DatabaseContext context) : base(context)
        {
        }

        public string GetWeatherConditionIdByCityId(string cityId)
        {
            return _dbContext.WeatherCondition.Where(wc => wc.CityId == cityId).FirstOrDefault().Id.ToString();
        }


    }
}
