using Common.DTO;
using ServiceAPI.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupplierUnitTest.Repository
{
    public class ServiceRepositoryMock : IserviceRepository
    {
        private readonly  List<HotelDto> hotelDtos;       

        public ServiceRepositoryMock()
        {
            hotelDtos = new List<HotelDto>()
            {
                new HotelDto(){
                 Hotels = new Hotel(){GeoId = 1419, Name = "Piazza Venezia", PropertyID = 1876, Rating =3 },
                 Rates = new List<Rate>()
                 {
                     new  Rate() { BoardType = "No Meals", RateType = "PerNight", Value = 1, FinalPrice = 0 },
                     new  Rate() { BoardType = "Half Board", RateType = "PerNight", Value = 1, FinalPrice = 0 },
                     new  Rate() { BoardType = "Full Board", RateType = "PerNight", Value = 1, FinalPrice = 0 }
                 }                 
                },
                new HotelDto(){
                 Hotels = new Hotel(){GeoId = 1, Name = "", PropertyID = 1419, Rating =3 },
                 Rates = new List<Rate>()
                 {
                     new  Rate() { BoardType = "No Meals", RateType = "Stay", Value = 1, FinalPrice = 0 },
                     new  Rate() { BoardType = "Half Board", RateType = "Stay", Value = 1, FinalPrice = 0 },
                     new  Rate() { BoardType = "Full Board", RateType = "Stay", Value = 1, FinalPrice = 0 }
                 }
                },
                new HotelDto(){
                 Hotels = new Hotel(){GeoId = 1, Name = "", PropertyID = 1419, Rating =3 },
                 Rates = new List<Rate>()
                 {
                     new  Rate() { BoardType = "No Meals", RateType = "PerNight", Value = 1, FinalPrice = 0 },
                     new  Rate() { BoardType = "Half Board", RateType = "PerNight", Value = 1, FinalPrice = 0 },
                     new  Rate() { BoardType = "Full Board", RateType = "PerNight", Value = 1, FinalPrice = 0 }
                 }
                }
            };
        }

        public Task<List<HotelDto>> FindBargain(int destinationId, int night)
        {        
            if(destinationId == 1419)
            {
                return Task.FromResult<List<HotelDto>>(hotelDtos);
            }
            else
            {
                List<HotelDto> hotelDto = new List<HotelDto>();
                return Task.FromResult<List<HotelDto>>(hotelDto);
            }
            
        }
    }
}
