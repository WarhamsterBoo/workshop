using System;
using Microsoft.AspNetCore.Mvc;

namespace workshop.verysmartapp.web.Controllers
{
    public class WeatherForecastController : Controller
    {
        // http://localhost:5000/WeatherForecast/Today?city=Moscow
        public JsonResult Today(string city)
        {
            return Json(new
            {
                Date = DateTime.Today,
                City = city,
                TemperatureC = -17
            });
        }
    }
}