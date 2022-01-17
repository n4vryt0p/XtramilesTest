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
    }
}
