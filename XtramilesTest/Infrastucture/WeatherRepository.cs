using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using XtramilesTest.WebAPI.Models;

namespace XtramilesTest.WebAPI.Infrastucture
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly Dictionary<int, WeatherData> items;
        //private readonly IJSONOpts _jSONOpts;

        public WeatherRepository(IJSONOpts jSONOpts)
        {
            items = new Dictionary<int, WeatherData>();
            //_jSONOpts = jSONOpts;
            var dataText = System.IO.File.ReadAllText(@"Data/weather1.json");
            JsonSerializer.Deserialize<List<WeatherData>>(dataText, jSONOpts.JOpts()).ForEach(r => AddWeatherData(r));
        }

        public WeatherData this[int id] => items.ContainsKey(id) ? items[id] : null;

        public IEnumerable<WeatherData> WeatherDatas => items.Values;

        public WeatherData AddWeatherData(WeatherData weatherData)
        {
            if (weatherData.City.Id == 0)
            {
                int key = items.Count;
                while (items.ContainsKey(key)) { key++; };
                weatherData.City.Id = key;
            }
            items[weatherData.City.Id] = weatherData;
            return weatherData;
        }

        //public void DeleteWeatherData(int id) => items.Remove(id);

        public IEnumerable<City> GetCity(string country) => items.Values.Select(x => x.City).Where(r => r.Country == country);
    }
}
