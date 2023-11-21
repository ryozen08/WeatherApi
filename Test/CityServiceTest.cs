using Model;
using Moq;
using Repository;
using Service;
using Service.Interfaces;

namespace Test
{
    [TestFixture]
    public class CityServiceTest
    {
        private Mock<ICityService> _cityServiceMock;
        private string _cityName;

        [SetUp]
        public void Setup()
        {
            _cityServiceMock = new Mock<ICityService>();
            _cityServiceMock.Setup(x => x.GetCity(It.IsAny<string>())).Callback<string>(city => _cityName = city);
        }

        [Test]
        [TestCase("Manila")]
        [TestCase("Cebu")]
        public void WeatherService_GetCity_Should_ReturnValue(string city)
        {
            var result = _cityServiceMock.Object.GetCity(city);
            Assert.AreEqual(city, _cityName);
        }
    }
}