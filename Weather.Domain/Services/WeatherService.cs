using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weather.Data.Entities;
using Weather.Data.Interfaces;
using Weather.Domain.DTO;
using Weather.Domain.Interfaces;
using Weather.Domain.BusinessModel;
using Microsoft.Extensions.Caching.Memory;

namespace Weather.Domain.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private IMemoryCache cache;
        public WeatherService(IUnitOfWork uow, IMapper mapper, IMemoryCache cache)
        {
            this.uow = uow;
            this.mapper = mapper;
            this.cache = cache;
        }

        public void AddTemperatureLog(string cityId, TemperatureLogDTO temperatureLogDTO)
        {
            TemperatureLog temperatureLog = mapper.Map<TemperatureLog>(temperatureLogDTO);
            string weatheConditionId = uow.WeatherCondition.GetWeatherConditionIdByCityId(cityId);
            if (!string.IsNullOrEmpty(weatheConditionId))
            {
                temperatureLog.WeatherConditionId = weatheConditionId;

                if (temperatureLog.Id == null)
                {
                    temperatureLog.Id = new Guid();
                }
                temperatureLog.IsArchived = false;
                uow.TemperatureLog.AddAsync(temperatureLog);
            }
        }

        public async Task<WeatherConditionDTO> GetWeatherCondition(string cityId)
        {
            if (!cache.TryGetValue(cityId, out WeatherConditionDTO weatherConditionDTO))
            {
                WeatherCondition weatherCondition = await uow.WeatherCondition.GetByIdAsync(uow.WeatherCondition.GetWeatherConditionIdByCityId(cityId));
                if (weatherCondition != null)
                {
                    weatherConditionDTO = mapper.Map<WeatherConditionDTO>(weatherCondition);
                    List<int> temperature = uow.TemperatureLog.GetTemperatureByWeatherConditionId(weatherConditionDTO.Id);
                    WeatherStatistics statistics = new WeatherStatistics(weatherConditionDTO, temperature);
                    statistics.SetStatistics();
                    cache.Set(cityId, weatherConditionDTO, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(2)));
                }
            }
            return weatherConditionDTO;
        }

        public async Task<TemperatureLogDTO> GetTemperatureLog(string idTempLog)
        {
            return mapper.Map<TemperatureLogDTO>(await uow.TemperatureLog.GetByIdAsync(idTempLog));
        }

        public async Task UpdateTemperatureLod(string cityId, TemperatureLogDTO temperatureLogDTO)
        {
            TemperatureLog temperatureLog = mapper.Map<TemperatureLog>(temperatureLogDTO);
            if (string.IsNullOrEmpty(temperatureLog.WeatherConditionId))
            {
                string weatheConditionId = uow.WeatherCondition.GetWeatherConditionIdByCityId(cityId);
                if (!string.IsNullOrEmpty(weatheConditionId))
                {
                    temperatureLog.WeatherConditionId = weatheConditionId;
                }
            }
            TemperatureLog temperatureLogOrigin = uow.TemperatureLog.GetTemperatureLogByCityIdAndDate(cityId, temperatureLog.DateTime);
            temperatureLog.Id = temperatureLogOrigin.Id;
            temperatureLog.IsArchived = temperatureLogOrigin.IsArchived;
            await uow.TemperatureLog.UpdateAsync(temperatureLog);
        }

        public List<TemperatureLogDTO> GetTemperatureLogs(string cityId)
        {
            List<TemperatureLogDTO> temperatureLogs = mapper.Map<List<TemperatureLogDTO>>(uow.TemperatureLog.GetTemperatureLogListByCityId(cityId));
            return temperatureLogs;
        }

        public async Task AchiveTemperatureLog(string cityId, DateTime dateStart, DateTime dateFinish)
        {
            List<TemperatureLog> temperatureLogs = uow.TemperatureLog.GetTemperatureLogListByCityIdAndDates(cityId, dateStart, dateFinish);
            foreach (var log in temperatureLogs)
            {
                log.IsArchived = true;
                await uow.TemperatureLog.UpdateAsync(log);
            }
        }
    }
}

