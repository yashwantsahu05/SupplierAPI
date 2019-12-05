using System.Collections.Generic;

namespace Common.DTO
{
    public class HotelDto
    {
        public Hotel Hotels { get; set; }
        public List<Rate> Rates { get; set; }

    }

    public class Hotel
    {
        public int PropertyID { get; set; }
        public string Name { get; set; }
        public int GeoId { get; set; }
        public int Rating { get; set; }
    }


    public class Rate
    {
        public string RateType { get; set; }
        public string BoardType { get; set; }
        public decimal Value { get; set; }
        public decimal FinalPrice { get; set; }
    }
}
