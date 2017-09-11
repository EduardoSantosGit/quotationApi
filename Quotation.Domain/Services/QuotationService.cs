using Services.quotation.Quotation.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.quotation.Quotation.Domain.Services
{
    public class QuotationService
    {
        private QuotationServiceScrap _quotationServiceScrap;

        public async Task<Coins> GetValuesCoins()
        {
            var coins = new Coins();
            _quotationServiceScrap = new QuotationServiceScrap();
            var block = await _quotationServiceScrap.GetScrapCoins();
            coins.Dolar = _quotationServiceScrap.GetValueDolar(block);
            coins.Euro = _quotationServiceScrap.GetValueEuro(block);
            return coins;
        }
    }
}
