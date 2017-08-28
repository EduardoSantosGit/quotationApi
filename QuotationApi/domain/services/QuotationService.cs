using System.Collections.Generic;
using System.Threading.Tasks;
using QuotationApi.domain.models;

namespace QuotationApi.domain.services
{
    public class QuotationService
    {
        private QuotationServiceScrap _quotationServiceScrap; 
            
        public async Task<Coins> GetValues()
        {
            var coins = new Coins();
            _quotationServiceScrap = new QuotationServiceScrap();
            var block = await _quotationServiceScrap.GetScrapCoins();
            coins.Dolar = _quotationServiceScrap.GetValueDolar(block);
            coins.Euro = _quotationServiceScrap.GetValueEuro(block);
            return coins;
        }

        public async Task<List<Quotation>> GetValuesQuotation()
        {
            _quotationServiceScrap = new QuotationServiceScrap();
            var block = await _quotationServiceScrap.GetScrapQuotation();
            var index = _quotationServiceScrap.GetValuesIndexParents(block);
            return index;
        }
    }
}