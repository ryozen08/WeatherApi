using Model;

namespace Service.Interfaces
{
    public interface ICityService
    {
        City GetCity(string cityName);
    }
}