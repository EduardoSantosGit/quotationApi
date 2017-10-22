using Services.markets.WorldMarkets.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.markets.WorldMarkets.Domain.Services
{
    public class WorldMarketsService
    {
        private WorldMarketsServiceScrap _worldMarketsServiceScrap;

        public WorldMarketsService(
            WorldMarketsServiceScrap worldMarketsServiceScrap)
        {
            _worldMarketsServiceScrap = worldMarketsServiceScrap;
        }
        public async Task<List<WorldMarket>> GetValuesWorldMarkets()
        {
            var block = await _worldMarketsServiceScrap.GetScrapWorldMarket();
            var index = _worldMarketsServiceScrap.GetValuesIndexParents(block);
            return index;
        }

    }
}
