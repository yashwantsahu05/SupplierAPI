using Common.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceAPI.Interface
{
    public interface IserviceRepository
    {
        Task<List<HotelDto>> FindBargain(int destinationId, int night);
    }
}
