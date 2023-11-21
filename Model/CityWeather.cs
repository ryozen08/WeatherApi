using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CityWeather : Entity
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public decimal TempCelsius { get; set; }
        public string Condition { get; set; }
        public decimal WindSpeed { get; set; }
        public string WindDirection { get; set; }
        public decimal WindDegree { get; set; }
        public decimal WindGust { get; set; }
        public decimal Pressure { get; set; }
        public decimal TempFeelsLike { get; set; }
        public decimal Humidity { get; set; }
        public virtual City City { get; set; }

    }
}
