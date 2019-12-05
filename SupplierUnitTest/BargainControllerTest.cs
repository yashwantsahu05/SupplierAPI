using ServiceAPI.Interface;
using SupplierAPI.Controllers;
using SupplierUnitTest.Repository;
using Xunit;

namespace SupplierUnitTest
{
    public class BargainControllerTest
    {
        private BargainController _controller;
        private IserviceRepository _repository;

        public BargainControllerTest()
        {
            _repository = new ServiceRepositoryMock();
            _controller = new BargainController(_repository);
        }       

        [Fact]
        public void Get_WhenCalled_Return_HotelList()
        {
            // Act
            var result = _controller.Get(1419, 2);
            // Assert            
            Assert.Contains("Piazza Venezia", result.Result[0].Hotels.Name);
        }

        [Fact]
        public void Get_WhenCalled_Return_Null()
        {
            // Act
            var result = _controller.Get(1, 2);
            // Assert            
            Assert.Contains("0", result.Result.Count.ToString());
        }

        [Fact]
        public void Get_WhenCalled_Final_For_RateType_PerNight()
        {
            // Act
            var result = _controller.Get(1419, 2);
            // Assert            
            Assert.Contains("2", result.Result[0].Rates[0].FinalPrice.ToString());
        }

        [Fact]
        public void Get_WhenCalled_Final_For_RateType_Stay()
        {
            // Act
            var result = _controller.Get(1419, 2);
            // Assert            
            Assert.Contains("1", result.Result[1].Rates[0].FinalPrice.ToString());
        }

    }
}
