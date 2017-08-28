using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace QuotationApi.domain.services.api
{
    public class QuotatioServicesApi
    {
        private HttpClient _httpClient;
        
        public async Task<string> GetPageIndex()
        {
            try
            {
                _httpClient = new HttpClient();
                var response = await _httpClient.GetAsync("http://exame.abril.com.br/");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return response.Content.ReadAsStringAsync().Result;
                }
            }
            catch (Exception ex)
            {
                return "";
            }
            return "";
        }

        public async Task<string> GetPageQuotaton()
        {
            try
            {
                _httpClient = new HttpClient();
                var response = await _httpClient.GetAsync("http://exame.advfn.com/");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return response.Content.ReadAsStringAsync().Result;
                }
            }
            catch (Exception ex)
            {
                return "";
            }
            return "";
        }
    }
}