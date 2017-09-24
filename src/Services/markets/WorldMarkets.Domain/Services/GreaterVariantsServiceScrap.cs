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

        public GreaterVariantsServiceScrap()
        {
            _scrapParser = new ScrapParser();
        }

        public async Task<string> GetBlockGreaterHigh()
        {
            _worldMarketServicesApi = new WorldMarketServicesApi();
            var html = await _worldMarketServicesApi.GetPagesLarger();

            var blockLarger =
                _scrapParser.ScrapBlockPage(html, "<h3>Maiores Altas (%)</h3>",
                    "<strong>Veja outros toptlists na ADVFN</strong></a></span>");

            return blockLarger;
        }

        public async Task<List<GreaterVariants>> GetListGreatersHigh(string block)
        {
            var lstGreatersVariants = new List<GreaterVariants>();
           
            var blockVariant = block;

            for(var i = 0; i < 60; i++)
            {
                var greatersVariants = new GreaterVariants();

                greatersVariants.Name = _scrapParser.ScrapBlockPage(blockVariant, "</div></th></tr><tr><td class",
                    "</span></div></td></tr>");

                blockVariant = _scrapParser.ClippingBlock(blockVariant, "</div></th></tr><tr><td class",
                        "</span></div></td></tr>", 16);

                lstGreatersVariants.Add(greatersVariants);
            }
            
            return lstGreatersVariants;
        }

        public async Task<GreaterVariants> GetParseGreaterVariants(string line)
        {



            return null;
        }

    }
}
