using System.IO;
using System.Net.Http;

namespace ServiceAPI.Interface
{
    public interface IHttp
    {
        HttpResponseMessage PostAsync(HttpClient httpclient, string requestUri, HttpContent content);
        string PostAsyncString(HttpClient httpclient, string requestUri, HttpContent content);
        Stream PostAsyncStream(HttpClient httpclient, string requestUri, HttpContent content);
        HttpResponseMessage GetAsync(HttpClient httpclient, string requestUri);
        Stream GetAsyncStream(HttpClient httpclient, string requestUri);
        string GetAsyncString(HttpClient httpclient, string requestUri);
        HttpResponseMessage PutAsync(HttpClient httpclient, string requestUri, HttpContent content);
    }
}
