using Model;
using Moq;
using Repository;
using Service;
using Service.Interfaces;

namespace Test
{
    [TestFixture]
    public class WeatherServiceTest
    {
        private Mock<IWeatherService> _weatherServiceMock;

        [SetUp]
        public void Setup()
        {
            _weatherServiceMock = new Mock<IWeatherService>();
            _weatherServiceMock.Setup(x => x.GetCityWeather(It.IsAny<string>())).ReturnsAsync(new CityWeather());
        }

        [Test]
        [TestCase("Manila")]
        public void WeatherService_GetCityWeather_Should_ReturnWeather(string city)
        {
            var result = _weatherServiceMock.Object.GetCityWeather(city).Result;
            Assert.IsNotNull(result);
        }
    }
}