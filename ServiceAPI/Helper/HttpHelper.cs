using ServiceAPI.Interface;
using System.IO;
using System.Net.Http;

namespace ServiceAPI.Helper
{
    public class HttpHelper : IHttp
    {
        private IHttp _HttpHelper;

        public HttpHelper(IHttp httpUtility)
        {
            _HttpHelper = httpUtility;
        }

        public void Dispose()
        {
            if (this._HttpHelper != null)
            {
                this._HttpHelper = null;
            }
        }

        public HttpResponseMessage GetAsync(HttpClient httpclient, string requestUri)
        {
            return httpclient.GetAsync(requestUri).Result;
        }

        public Stream GetAsyncStream(HttpClient httpclient, string requestUri)
        {
            return httpclient.GetStreamAsync(requestUri).Result;
        }

        public string GetAsyncString(HttpClient httpclient, string requestUri)
        {
            return httpclient.GetStringAsync(requestUri).Result;
        }

        public HttpResponseMessage PostAsync(HttpClient httpclient, string requestUri, HttpContent content)
        {
            return httpclient.PostAsync(requestUri, content).Result;
        }

        public Stream PostAsyncStream(HttpClient httpclient, string requestUri, HttpContent content)
        {
            return httpclient.PostAsync(requestUri, content).Result.Content.ReadAsStreamAsync().Result;
        }

        public string PostAsyncString(HttpClient httpclient, string requestUri, HttpContent content)
        {
            return httpclient.PostAsync(requestUri, content).Result.Content.ReadAsStringAsync().Result;
        }

        public HttpResponseMessage PutAsync(HttpClient httpclient, string requestUri, HttpContent content)
        {
            return httpclient.PutAsync(requestUri, content).Result;
        }
    }
}
