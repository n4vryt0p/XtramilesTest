using System.Collections.Generic;
using System.Text.Json;
using XtramilesTest.WebAPI.Models;

namespace XtramilesTest.WebAPI.Infrastucture
{
    public class CountryRepository : ICountryRepository
    {
        private readonly Dictionary<string, Countries> items;

        public CountryRepository(IJSONOpts jSONOpts)
        {
            items = new Dictionary<string, Countries>();
            var dataText = System.IO.File.ReadAllText(@"Data/countries.json");
            JsonSerializer.Deserialize<List<Countries>>(dataText, jSONOpts.JOpts()).ForEach(r => AddCountries(r));
        }

        //public Countries this[string id] => items.ContainsKey(id) ? items[id] : null;

        public IEnumerable<Countries> Countrieses => items.Values;

        public Countries AddCountries(Countries Countries)
        {
            items[Countries.Abbreviation] = Countries;
            return Countries;
        }
    }
}
