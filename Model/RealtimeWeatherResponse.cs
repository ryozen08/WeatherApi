using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{

    public class RealtimeWeatherResponse
    {
        public CurrentWeather current { get; set; }
        public WeatherLocation location { get; set; }

    }

    public class CurrentWeather
    {
        public WeatherCondition condition { get; set; }
        public decimal temp_c { get; set; }
        public decimal wind_kph { get; set; }
        public string wind_dir { get; set; }
        public decimal wind_degree { get; set; }
        public decimal gust_kph { get; set; }
        public decimal pressure_mb { get; set; }
        public decimal feelslike_c { get; set; }
        public decimal humidity { get; set; }
    }

    public class WeatherCondition
    {
        public string text { get; set; }
        public string icon { get; set; }
    }

    public class WeatherLocation
    {
        public string name { get; set; }
        public string country { get; set; }
        public string region { get; set; }

    }
}
