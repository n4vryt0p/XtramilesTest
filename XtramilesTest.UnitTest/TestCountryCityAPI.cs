using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using XtramilesTest.WebAPI.Controllers;
using XtramilesTest.WebAPI.Infrastucture;
using XtramilesTest.WebAPI.Models;
using Xunit;

namespace XtramilesTest.UnitTest
{
    public class TestCountryCityAPI
    {
        [Fact]
        public void Test_GET_AllCountries()
        {
            // Arrange
            var mockRepo = new Mock<ICountryRepository>();
            mockRepo.Setup(repo => repo.Countrieses).Returns(MultipleCity());
            var controller = new CountryController(mockRepo.Object);

            // Act
            var result = controller.Get();

            // Assert
            var model = Assert.IsAssignableFrom<IEnumerable<Countries>>(result);
            Assert.Equal(5, model.Count());
        }

        [Fact]
        public void Test_GET_ACity_Ok()
        {
            // Arrange
            string id = "VE";
            var mockRepo = new Mock<IWeatherRepository>();
            mockRepo.Setup(repo => repo[It.IsAny<string>()]).Returns<string>((id) => MultipleCities(id));
            var controller = new WeatherForecastController(mockRepo.Object);

            // Act
            var result = controller.GetCities(id);

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<City>>>(result);
            var actionValue = Assert.IsType<OkObjectResult>(actionResult.Result);
            Assert.Equal(id, ((IEnumerable<City>)actionValue.Value).First().Country);
        }

        [Fact]
        public void Test_GET_ACity_BadRequest()
        {
            // Arrange
            string id = string.Empty;
            var mockRepo = new Mock<IWeatherRepository>();
            mockRepo.Setup(repo => repo[It.IsAny<string>()]).Returns<string>((a) => MultipleCities(a));
            var controller = new WeatherForecastController(mockRepo.Object);

            // Act
            var result = controller.GetCities(id);

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<City>>>(result);
            Assert.IsType<BadRequestObjectResult>(actionResult.Result);
        }

        [Fact]
        public void Test_GET_ACity_NotFound()
        {
            // Arrange
            string id = "USSS";
            var mockRepo = new Mock<IWeatherRepository>();
            mockRepo.Setup(repo => repo[It.IsAny<string>()]).Returns<string>((id) => MultipleCities(id));
            var controller = new WeatherForecastController(mockRepo.Object);

            // Act
            var result = controller.GetCities(id);

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<City>>>(result);
            Assert.IsType<NotFoundResult>(actionResult.Result);
        }

        private static IEnumerable<City> MultipleCities(string id)
        {
            IEnumerable<City> reservations = MultipleWeather().Select(s =>s.City);
            return reservations.Where(a => a.Country == id);
        }

        private static IEnumerable<WeatherData> MultipleWeather()
        {
            var r = new List<WeatherData>();
            r.Add(new WeatherData()
            {
                City = new City
                {
                    Id = 1,
                    Name = "Kathmandu",
                    Country = "NP",
                    Coord = new Coord
                    {
                        Lon = 85,
                        Lat = 27.716667
                    }
                },
                Time = 1489487389
            });
            r.Add(new WeatherData()
            {
                City = new City
                {
                    Id = 2,
                    Name = "Merida",
                    Country = "VE",
                    Coord = new Coord
                    {
                        Lon = -71.144997,
                        Lat = 27.716667
                    }
                },
                Time = 1489487389
            });
            r.Add(new WeatherData()
            {
                City = new City
                {
                    Id = 1280737,
                    Name = "Lhasa",
                    Country = "CN",
                    Coord = new Coord
                    {
                        Lon = 91.099998,
                        Lat = 29.65
                    }
                },
                Time = 1489487390
            });
            return r;
        }

        private static IEnumerable<Countries> MultipleCity()
        {
            var r = new List<Countries>();
            r.Add(new Countries()
            {
                Country = "Indonesia",
                Abbreviation = "ID"
            });
            r.Add(new Countries()
            {
                Country = "United State",
                Abbreviation = "US"
            });
            r.Add(new Countries()
            {
                Country = "Australia",
                Abbreviation = "AU"
            });
            r.Add(new Countries()
            {
                Country = "United Kingdom",
                Abbreviation = "UK"
            });
            r.Add(new Countries()
            {
                Country = "Singapore",
                Abbreviation = "SG"
            });
            return r;
        }
    }
}
