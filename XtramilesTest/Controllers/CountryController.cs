using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using XtramilesTest.WebAPI.Infrastucture;
using XtramilesTest.WebAPI.Models;

namespace XtramilesTest.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository countryRepository;
        public CountryController(ICountryRepository repo) => countryRepository = repo;

        [HttpGet]
        public IEnumerable<Countries> Get() => countryRepository.Countrieses;

        //[HttpGet("{id}")]
        //public ActionResult<Countries> Get(string id)
        //{
        //    if (string.IsNullOrEmpty(id))
        //        return BadRequest("Value must be passed in the request body.");

        //    Countries r = countryRepository[id];

        //    if (r is null)
        //        return NotFound();

        //    return Ok(r);
        //}

        //[HttpPost]
        //public Countries Post([FromBody] Countries res) =>
        //countryRepository.AddCountries(new Countries
        //{
        //    Country = res.Country,
        //    Abbreviation = res.Abbreviation
        //});
    }
}
