using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using XtramilesTest.Controllers;
using XtramilesTest.WebAPI.Infrastucture;
using XtramilesTest.WebAPI.Models;
using Xunit;

namespace XtramilesTest.UnitTest
{
    public class TestAPI
    {
        [Fact]
        public void Test_GET_AllWeatherData()
        {
            // Arrange
            var mockRepo = new Mock<IWeatherRepository>();
            mockRepo.Setup(repo => repo.WeatherDatas).Returns(Multiple());
            var controller = new WeatherForecastController(mockRepo.Object);

            // Act
            var result = controller.Get();

            // Assert
            var model = Assert.IsAssignableFrom<IEnumerable<WeatherData>>(result);
            Assert.Equal(3, model.Count());
        }

        [Fact]
        public void Test_GET_AWeather_Ok()
        {
            // Arrange
            int id = 1;
            var mockRepo = new Mock<IWeatherRepository>();
            mockRepo.Setup(repo => repo[It.IsAny<int>()]).Returns<int>((id) => Single(id));
            var controller = new WeatherForecastController(mockRepo.Object);

            // Act
            var result = controller.Get(id);

            // Assert
            var actionResult = Assert.IsType<ActionResult<WeatherData>>(result);
            var actionValue = Assert.IsType<OkObjectResult>(actionResult.Result);
            Assert.Equal(id, ((WeatherData)actionValue.Value).City.Id);
        }

        [Fact]
        public void Test_GET_AWeather_BadRequest()
        {
            // Arrange
            int id = 0;
            var mockRepo = new Mock<IWeatherRepository>();
            mockRepo.Setup(repo => repo[It.IsAny<int>()]).Returns<int>((a) => Single(a));
            var controller = new WeatherForecastController(mockRepo.Object);

            // Act
            var result = controller.Get(id);

            // Assert
            var actionResult = Assert.IsType<ActionResult<WeatherData>>(result);
            Assert.IsType<BadRequestObjectResult>(actionResult.Result);
        }

        private static WeatherData Single(int id)
        {
            IEnumerable<WeatherData> reservations = Multiple();
            return reservations.Where(a => a.City.Id == id).FirstOrDefault();
        }

        private static IEnumerable<WeatherData> Multiple()
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
    }
}