using Model;

namespace Service.Interfaces
{
    public interface IWeatherService
    {
        Task<CityWeather> GetCityWeather(string city);
    }
}