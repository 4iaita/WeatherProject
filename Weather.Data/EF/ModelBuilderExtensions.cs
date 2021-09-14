using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Weather.Data.Entities;

namespace Weather.Data.EF
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            List<City> cities = new List<City>()
            {
                new City()
                {
                    Id = Guid.NewGuid(),
                    Name = "Kharkov",
                },
                new City()
                {
                    Id = Guid.NewGuid(),
                    Name = "Odessa"
                },
                new City()
                {
                    Id = Guid.NewGuid(),
                    Name = "Kiev"
                }
            };

            List<WeatherCondition> weatherConditions = new List<WeatherCondition>()
            {
                new WeatherCondition()
                {
                    Id = Guid.NewGuid(),
                    CurrentTemperature = 13,
                    CityId = cities[0].Id.ToString()
                },
                 new WeatherCondition()
                {
                    Id = Guid.NewGuid(),
                    CurrentTemperature = 12,
                    CityId = cities[1].Id.ToString()
                },
                  new WeatherCondition()
                {
                    Id = Guid.NewGuid(),
                    CurrentTemperature = 14,
                    CityId = cities[2].Id.ToString()
                },
            };


            List<TemperatureLog> temperatureLogs = new List<TemperatureLog>()
            {
                new TemperatureLog()
                {
                    Id = Guid.NewGuid(),
                    Temperature = 12,
                    DateTime = new DateTime(2021, 7, 20, 18, 30, 0),
                    WeatherConditionId = weatherConditions[0].Id.ToString(),
                    IsArchived = false
                },
                new TemperatureLog()
                {
                    Id = Guid.NewGuid(),
                    Temperature = 15,
                    DateTime = new DateTime(2021, 8, 19, 19, 30, 0),
                    WeatherConditionId = weatherConditions[0].Id.ToString(),
                    IsArchived = false
                },
                new TemperatureLog()
                {
                    Id = Guid.NewGuid(),
                    Temperature = 11,
                    DateTime = new DateTime(2021, 6, 10, 8, 30, 0),
                    WeatherConditionId = weatherConditions[1].Id.ToString(),
                    IsArchived = false
                },
                new TemperatureLog()
                {
                    Id = Guid.NewGuid(),
                    Temperature = 14,
                    DateTime = new DateTime(2021, 9, 6, 18, 10, 0),
                    WeatherConditionId = weatherConditions[1].Id.ToString(),
                    IsArchived = false
                },
                new TemperatureLog()
                {
                    Id = Guid.NewGuid(),
                    Temperature = 17,
                    DateTime = new DateTime(2021, 5, 10, 12, 30, 0),
                    WeatherConditionId = weatherConditions[2].Id.ToString(),
                    IsArchived = false
                },
                new TemperatureLog()
                {
                    Id = Guid.NewGuid(),
                    Temperature = 10,
                    DateTime = new DateTime(2021, 4, 15, 11, 30, 0),
                    WeatherConditionId = weatherConditions[2].Id.ToString(),
                    IsArchived = false
                }

            };

            modelBuilder.Entity<TemperatureLog>().HasData(temperatureLogs);
            modelBuilder.Entity<WeatherCondition>().HasData(weatherConditions);
            modelBuilder.Entity<City>().HasData(cities);
        }
    }
}
