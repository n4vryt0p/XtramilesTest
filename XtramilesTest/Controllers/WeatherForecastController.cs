using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XtramilesTest.WebAPI.Infrastucture;
using XtramilesTest.WebAPI.Models;

namespace XtramilesTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherRepository repository;
        public WeatherForecastController(IWeatherRepository repo) => repository = repo;

        [HttpGet]
        public IEnumerable<WeatherData> Get() => repository.WeatherDatas;

        [HttpGet("{id}")]
        public ActionResult<WeatherData> Get(int id)
        {
            if (id == 0)
                return BadRequest("Value must be passed in the request body.");

            WeatherData r = repository[id];

            if (r is null)
                return NotFound();

            return Ok(r);
        }

        //[HttpPost]
        //public WeatherData Post([FromBody] WeatherData res) =>
        //repository.AddWeatherData(new WeatherData
        //{
        //    City = res.City,
        //    Time = res.Time,
        //    Main = res.Main,
        //    Wind = res.Wind,
        //    Clouds = res.Clouds,
        //    Weather = res.Weather,
        //    Rain = res.Rain
        //});

        [HttpGet("City/{countryID}")]
        public IEnumerable<City> GetCities(string countryID) => repository.GetCity(countryID);

        //[HttpDelete("{id}")]
        //public void Delete(int id) => repository.DeleteWeatherData(id);
    }
}
