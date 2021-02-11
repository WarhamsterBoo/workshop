using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace workshop.verysmartapp.web.Controllers
{
    public class WeatherForecastController : Controller
    {
        private ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        // http://localhost:5000/WeatherForecast/Today?city=Moscow
        public JsonResult Today(string city)
        {
            _logger.LogInformation("Weather Forecast requested for {City}", city);
            
            return Json(new
            {
                Date = DateTime.Today,
                City = city,
                TemperatureC = -17
            });
        }
    }
}