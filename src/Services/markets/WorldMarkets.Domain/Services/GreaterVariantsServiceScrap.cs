using Services.markets.WorldMarkets.Domain.Common;
using Services.markets.WorldMarkets.Domain.Models;
using Services.markets.WorldMarkets.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.markets.WorldMarkets.Domain.Services
{
    public class GreaterVariantsServiceScrap
    {
        private readonly ScrapParser _scrapParser;
        private WorldMarketServicesApi _worldMarketServicesApi;

        public async Task<string> GetBlockGreaterHigh()
        {
            _worldMarketServicesApi = new WorldMarketServicesApi();
            var html = await _worldMarketServicesApi.GetPagesLarger();

            var blockLarger =
                _scrapParser.ScrapBlockPage(html, "<h3>Maiores Altas (%)</h3>",
                    "<strong>Veja outros toptlists na ADVFN</strong></a></span>");

            return blockLarger;
        }

        public async Task<string> GetListGreatersHigh(string block)
        {

            var greatersVariants = new List<GreaterVariants>();

            


            return "";
        }

    }
}
