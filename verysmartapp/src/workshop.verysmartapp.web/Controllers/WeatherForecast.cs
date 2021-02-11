using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Prometheus;

namespace workshop.verysmartapp.web.Controllers
{
    public class WeatherForecastController : Controller
    {
        private ILogger<WeatherForecastController> _logger;

        private static readonly Counter _counter = Metrics.CreateCounter("verysmartapp_sum_of_degrees",
            "Just pointless metric, nothing to see here");

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        // http://localhost:5000/WeatherForecast/Today?city=Moscow
        public JsonResult Today(string city)
        {
            _logger.LogInformation("Weather Forecast requested for {City}", city);

            var degrees = -17;
            
            _counter.Inc(Math.Abs(degrees));
            
            return Json(new
            {
                Date = DateTime.Today,
                City = city,
                TemperatureC = degrees
            });
        }
    }
}