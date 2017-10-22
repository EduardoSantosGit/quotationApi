using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Services.markets.WorldMarkets.Infrastructure.Interfaces
{
    public interface IRequestApi
    {
        Task<HttpClient> CreateGet(string url);
    }
}