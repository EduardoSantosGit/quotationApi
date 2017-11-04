using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WorldMarkets.Domain.Interfaces
{
    public interface IWorldMarketServicesApi
    {
        Task<string> GetPageWorldMarkets();
    }
}
