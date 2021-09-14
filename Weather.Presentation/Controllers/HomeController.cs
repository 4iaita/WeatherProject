using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather.Domain.Interfaces;
using Weather.Domain.DTO;
using Microsoft.AspNetCore.Http;
using Weather.Presentation.Models;
using AutoMapper;


namespace Weather.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IWeatherService weatherService;
        private readonly IMapper mapper;
        public HomeController(IWeatherService weatherService, IMapper mapper)
        {
            this.weatherService = weatherService;
            this.mapper = mapper;
        }
        [HttpGet("history/{cityId}")]
        public ActionResult GetHistory(string cityId)
        {
            try
            {
                return Ok(weatherService.GetTemperatureLogs(cityId));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error getting data");
            }
        }

        [HttpGet("weather/{cityId}")]
        public async Task<ActionResult<WeatherConditionViewModel>> GetWeather(string cityId)
        {
            try
            {
                WeatherConditionDTO weather = await weatherService.GetWeatherCondition(cityId);
                if (weather == null)
                {
                    return NotFound();
                }
                WeatherConditionViewModel weatherView = mapper.Map<WeatherConditionViewModel>(weather);
                weatherView.SetWeatherUnitOfMeasure();
                return weatherView;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error getting data");
            }
        }


        [HttpPatch("update/{cityId}")]
        public async Task<IActionResult> UpdateWeather(string cityId, TemperatureLogDTO temperatureLog)
        {
            try
            {
                if (temperatureLog == null || cityId == null)
                    return BadRequest();
                await weatherService.UpdateTemperatureLod(cityId, temperatureLog);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error data path");
            }
        }
        [HttpPatch("archive/{cityId}/{dateStart}/{dateFinish}")]
        public async Task<IActionResult> ArchiveWeather(string cityId, DateTime dateStart, DateTime dateFinish)
        {
            try
            {
                if (cityId == null || dateStart == null || dateFinish == null)
                    return BadRequest();
                await weatherService.AchiveTemperatureLog(cityId, dateStart, dateFinish);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error data path");
            }
        }

        [HttpPost("add/{cityId}")]
        public ActionResult<TemperatureLogDTO> AddWeather(string cityId, [FromBody] TemperatureLogDTO temperatureLog)
        {
            try
            {
                if (temperatureLog == null || cityId == null)
                    return BadRequest();


                weatherService.AddTemperatureLog(cityId, temperatureLog);

                return Ok(temperatureLog);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new weather condition record");
            }
        }

    }
}
