using Services.markets.WorldMarkets.Domain.Common;
using Services.markets.WorldMarkets.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorldMarkets.Domain.Interfaces;

namespace Services.markets.WorldMarkets.Domain.Services
{
    public class GreaterVariantsServiceScrap
    {
        private readonly ScrapParser _scrapParser;
        private readonly IWorldMarketServicesApi _worldMarketServicesApi;

        public GreaterVariantsServiceScrap(
            IWorldMarketServicesApi worldMarketServicesApi,
            ScrapParser scrapParser)
        {           
            _worldMarketServicesApi = worldMarketServicesApi;
            _scrapParser = scrapParser;
        }

        public async Task<string> GetBlockGreaterHigh()
        {
            var html = await _worldMarketServicesApi.GetPagesLarger();

            var blockLarger =
                _scrapParser.ScrapBlockPage(html, "<h3>Maiores Altas (%)</h3>",
                    "<strong>Veja outros toptlists na ADVFN</strong></a></span>");

            return blockLarger;
        }

        public async Task<List<GreaterVariants>> GetListGreatersHigh(string block)
        {
            var lstGreatersVariants = new List<GreaterVariants>();
            
            var blockVariant = block.Split("<td>");


            var a = blockVariant;

            /*
            for(var i = 0; i < 60; i++)
            {
                var greatersVariants = new GreaterVariants();

                greatersVariants.Name = _scrapParser.ScrapBlockPage(blockVariant, "</div></th></tr><tr><td class",
                    "</span></div></td></tr>");

                blockVariant = _scrapParser.ClippingBlock(blockVariant, "</div></th></tr><tr><td class",
                        "</span></div></td></tr>", 16);

                lstGreatersVariants.Add(greatersVariants);
            }
            
            return lstGreatersVariants;*/
            return null;
        }

        public async Task<GreaterVariants> GetParseGreaterVariants(string line)
        {
            var greatersVariants = new GreaterVariants();
            var blockId = _scrapParser.ScrapBlockPage(line, "=\"align_center width",
                    "<td><div class=");
            greatersVariants.Id = Convert.ToDouble(
                _scrapParser.ScrapBlockPage(line, "\">", "<td>"));

            return null;
        }

    }
}
