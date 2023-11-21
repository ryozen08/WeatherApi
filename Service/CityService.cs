using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Repository;
using Service.Interfaces;

namespace Service
{
    public class CityService : BaseService<City>, ICityService
    {

        public CityService(IRepository<City> repository) : base(repository)
        {
        }

        public City GetCity(string cityName)
        {
            City city = null;
            city = Repository.Find(x => x.Name == cityName).FirstOrDefault();

            return city;
        }
    }
}
