using System.Collections.Generic;

namespace XtramilesTest.WebAPI.Models
{
    public class WeatherData
    {
        public City City { get; set; }
        public int Time { get; set; }
        public Main Main { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }
        public List<Weather> Weather { get; set; }
        public Rain Rain { get; set; }
    }
    public class Coord
    {
        public double Lon { get; set; }
        public double Lat { get; set; }
    }

    public class Lang
    {
        public string Bg { get; set; }
        public string El { get; set; }
        public string En { get; set; }
        public string Es { get; set; }
        public string Ja { get; set; }
        public string Link { get; set; }
        public string No { get; set; }
        public string Ru { get; set; }
        public string Tr { get; set; }
        public string Zh { get; set; }
    }

    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Findname { get; set; }
        public string Country { get; set; }
        public Coord Coord { get; set; }
        public int Zoom { get; set; }
        public List<Lang> Langs { get; set; }
    }

    public class Main
    {
        public double Temp { get; set; }
        public double Pressure { get; set; }
        public int Humidity { get; set; }
        public double TempMin { get; set; }
        public double TempMax { get; set; }
        public double? SeaLevel { get; set; }
        public double? GrndLevel { get; set; }
    }

    public class Wind
    {
        public double Speed { get; set; }
        public double Deg { get; set; }
        public int VarBeg { get; set; }
        public int VarEnd { get; set; }
    }

    public class Clouds
    {
        public int All { get; set; }
    }

    public class Weather
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }

    public class Rain
    {
        public double _3h { get; set; }
    }
}
