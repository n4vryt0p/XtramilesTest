using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using XtramilesTest.WebAPI.Infrastucture;
using XtramilesTest.WebAPI.Models;

namespace XtramilesTest.WebAPI.Controllers
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

        [HttpGet("City/{countryID}")]
        public ActionResult<IEnumerable<City>> GetCities(string countryID)
        {
            if (string.IsNullOrEmpty(countryID))
                return BadRequest("Value must be passed in the request body.");

            IEnumerable<City> r = repository[countryID];

            if (r.Count() < 1)
                return NotFound();

            return Ok(r);
        }

        //[HttpGet("City/{countryID}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public IEnumerable<City> GetCities(string countryID) => repository[countryID];
    }
}
