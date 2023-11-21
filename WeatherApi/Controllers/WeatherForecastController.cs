using Microsoft.AspNetCore.Mvc;
using Model;
using Service;
using Service.Interfaces;

namespace WeatherApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherService _weatherService;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }

        [HttpGet("GetCityWeatherForecast")]
        public IActionResult GetCityWeatherForecast(string city)
        {
            var result = _weatherService.GetCityWeather(city).Result;
            return Ok(result);
        }
    }
}