using System.Collections.Generic;
using XtramilesTest.WebAPI.Models;

namespace XtramilesTest.WebAPI.Infrastucture
{
    public interface IWeatherRepository
    {
        IEnumerable<WeatherData> WeatherDatas { get; }
        WeatherData this[int id] { get; }
        WeatherData AddWeatherData(WeatherData weatherData);
        //IEnumerable<City> GetCity(string country);
        IEnumerable<City> this[string country] { get; }
        //void DeleteWeatherData(int id);
    }
}
