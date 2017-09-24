using Services.markets.WorldMarkets.Domain.Common;
using Services.markets.WorldMarkets.Domain.Models;
using Services.markets.WorldMarkets.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.markets.WorldMarkets.Domain.Services
{
    public class GreaterVariantsService
    {
       
        private GreaterVariantsServiceScrap _greaterVariantsServiceScrap;

        public async Task<List<GreaterVariants>> GetValuesGreaterVariants()
        {
            _greaterVariantsServiceScrap = new GreaterVariantsServiceScrap();
            var block = await _greaterVariantsServiceScrap.GetBlockGreaterHigh();
            await _greaterVariantsServiceScrap.GetListGreatersHigh(block);
            return null;
        }

    }
}
