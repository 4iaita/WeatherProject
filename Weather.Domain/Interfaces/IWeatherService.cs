using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weather.Domain.DTO;

namespace Weather.Domain.Interfaces
{
    public interface IWeatherService
    {
        void AddTemperatureLog(string cityId, TemperatureLogDTO temperatureLogDTO);
        Task<WeatherConditionDTO> GetWeatherCondition(string cityId);
        Task<TemperatureLogDTO> GetTemperatureLog(string idTempLog);
        Task UpdateTemperatureLod(string cityId, TemperatureLogDTO temperatureLogDTO);
        List<TemperatureLogDTO> GetTemperatureLogs(string cityId);
        Task AchiveTemperatureLog(string cityId, DateTime dateStart, DateTime dateFinish);
    }
}
