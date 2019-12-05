using Common.DTO;
using Microsoft.AspNetCore.Mvc;
using ServiceAPI.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupplierAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BargainController : ControllerBase
    {
        private IserviceRepository _serviceRepo;
        public BargainController(IserviceRepository iserviceRepo)
        {
            _serviceRepo = iserviceRepo;
        }

        // GET: api/Bargain/1419/2
        [HttpGet("{destinationId}/{night}")]
        public async Task<List<HotelDto>> Get(int destinationId, int night)
        {
            List<HotelDto> hotelDtos = await _serviceRepo.FindBargain(destinationId, night);

            if (hotelDtos.Count > 0)
            {
                Parallel.ForEach(hotelDtos, hotel =>
                {
                    Parallel.ForEach(hotel.Rates, rate =>
                    {
                        if (rate.RateType == "PerNight")
                            rate.FinalPrice = night * rate.Value;
                        else
                            rate.FinalPrice = rate.Value;
                    });
                });
            }

            return hotelDtos;
        }       

    }
}
