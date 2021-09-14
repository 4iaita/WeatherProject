using System;
using System.Collections.Generic;
using System.Text;
using Weather.Data.Entities;

namespace Weather.Data.Interfaces
{
    public interface ITemperatureLogRepository:IGenericRepository<TemperatureLog>
    {
        List<int> GetTemperatureByWeatherConditionId(string id);
        TemperatureLog GetTemperatureLogByCityIdAndDate(string cityId, DateTime date);
        List<TemperatureLog> GetTemperatureLogListByCityId(string cityId);
        List<TemperatureLog> GetTemperatureLogListByCityIdAndDates(string cityId, DateTime dateStart, DateTime dateFinish);
    }
}
