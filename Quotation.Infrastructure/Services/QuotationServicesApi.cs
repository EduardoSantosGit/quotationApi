using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.Infrastructure.Services
{
    public class QuotationServicesApi
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
    }
}
