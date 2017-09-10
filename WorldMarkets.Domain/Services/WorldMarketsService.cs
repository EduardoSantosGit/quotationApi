using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorldMarkets.Domain.Models;

namespace WorldMarkets.Domain.Services
{
    public class WorldMarketsService
    {
        private WorldMarketsServiceScrap _worldMarketsServiceScrap;

        public async Task<List<WorldMarket>> GetValuesWorldMarkets()
        {
            _worldMarketsServiceScrap = new WorldMarketsServiceScrap();
            var block = await _worldMarketsServiceScrap.GetScrapWorldMarket();
            var index = _worldMarketsServiceScrap.GetValuesIndexParents(block);
            return index;
        }

    }
}
