using Model;
using Newtonsoft.Json;
using Repository;
using RestSharp;
using Service.Interfaces;

namespace Service
{
    public class WeatherService : BaseService<CityWeather>, IWeatherService
    {
        private readonly string _weatherApiUrl = "https://weatherapi-com.p.rapidapi.com/current.json";
        private readonly ICityService _cityService;
        
        public WeatherService(IRepository<CityWeather> repository, ICityService cityService) : base(repository)
        {
            _cityService = cityService;
        }

        public async Task<CityWeather> GetCityWeather(string city)
        {
            if(string.IsNullOrEmpty(city))
                return new CityWeather();

            var requestUrl = _weatherApiUrl + $"?q={city}";
            var client = new RestClient(requestUrl);
            var request = new RestRequest("");
            request.AddHeader("X-RapidAPI-Key", "5b312785bemsh40e3e83d6f5fdc1p18092ajsnce016f6e0f48");
            request.AddHeader("X-RapidAPI-Host", "weatherapi-com.p.rapidapi.com");
            RestResponse response = client.Execute(request);
            RealtimeWeatherResponse weatherResponse =
                JsonConvert.DeserializeObject<RealtimeWeatherResponse>(response.Content);

            var cityWeather = new CityWeather();
            var cityObj = _cityService.GetCity(city);

            if (cityObj != null)
            {
                cityWeather.City = cityObj;
            }
            else
            {
                cityWeather.City = new City
                    { Country = weatherResponse.location.country, Name = weatherResponse.location.name };
            }

            cityWeather.Condition = weatherResponse.current.condition.text;
            cityWeather.Humidity = weatherResponse.current.humidity;
            cityWeather.Pressure = weatherResponse.current.pressure_mb;
            cityWeather.TempCelsius = weatherResponse.current.temp_c;
            cityWeather.TempFeelsLike = weatherResponse.current.feelslike_c;
            cityWeather.WindDegree = weatherResponse.current.wind_degree;
            cityWeather.WindDirection = weatherResponse.current.wind_dir;
            cityWeather.WindSpeed = weatherResponse.current.wind_kph;
            cityWeather.WindGust = weatherResponse.current.gust_kph;

            Repository.Create(cityWeather);
            await Repository.SaveChangesAsync();
            cityWeather = Repository.Find(x => x.City.Name == city).MaxBy(x => x.Id);
            
            return cityWeather;
        }
    }


}