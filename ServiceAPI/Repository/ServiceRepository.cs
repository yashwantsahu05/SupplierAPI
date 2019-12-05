using Common.DTO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ServiceAPI.Helper;
using ServiceAPI.Interface;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace ServiceAPI.Repository
{
    public class ServiceRepository : IserviceRepository
    {
        private IConfiguration _configuration;
        private IHttp _httpHelper;

        public ServiceRepository(IConfiguration iConfig)
        {
            _configuration = iConfig;
            
        }

        public async Task<List<HotelDto>> FindBargain(int destinationId, int night)
        {
            try
            {
                List<HotelDto> hotelDtos = new List<HotelDto>();
                var httpClient = new HttpClient();
                HttpHelper httpHelper = new HttpHelper(_httpHelper);
                var uri = new Uri(_configuration.GetValue<string>("ApiSetting:apiUri"));
                var qs = HttpUtility.ParseQueryString(uri.Query);
                qs.Set("destinationId", destinationId.ToString());
                qs.Set("nights", night.ToString());
                qs.Set("code", _configuration.GetValue<string>("ApiSetting:code"));
                var uriBuilder = new UriBuilder(uri);
                uriBuilder.Query = qs.ToString();
                var response = httpHelper.GetAsync(httpClient, uriBuilder.Uri.ToString());
                string apiResponse = await response.Content.ReadAsStringAsync();
                hotelDtos = JsonConvert.DeserializeObject<List<HotelDto>>(apiResponse);
                
                return hotelDtos;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
