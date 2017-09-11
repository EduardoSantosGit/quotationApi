using Services.quotation.Quotation.Domain.Services;
using Services.quotation.Quotation.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.quotation.Quotation.Domain.Services
{
    public class QuotationServiceScrap
    {
        private readonly ScrapService _scrapService;
        private QuotationServicesApi _quotationServicesApi;

        public QuotationServiceScrap()
        {
            _scrapService = new ScrapService();
        }

        public async Task<string> GetScrapCoins()
        {
            _quotationServicesApi = new QuotationServicesApi();
            var html = await _quotationServicesApi.GetPageIndex();

            var blockQuotation =
                _scrapService.ScrapBlockPage(html, "abril_exame_cotacoes_widget-48", "abrAD_button1");

            var blockValuesQuotation =
                _scrapService.ScrapBlockPage(blockQuotation, "<div class=\"exchange-container\">",
                    "<div class=\"bvsp\">"
            );

            return blockValuesQuotation;
        }

        public string GetValueDolar(string block)
        {
            var blockDolar = _scrapService.ScrapBlockPage(
                block, "<div class=\"exchange exchange-usd\">",
                "</div>");

            var value = _scrapService.ScrapBlockPage(
                blockDolar, "<span class=\"value\">",
                "</span>");

            return value;
        }

        public string GetValueEuro(string block)
        {
            var blockEuro = _scrapService.ScrapBlockPage(
                block, "<div class=\"exchange exchange-eur\">",
                "<div class=\"exchange exchange-selic\">");

            var value = _scrapService.ScrapBlockPage(
                blockEuro, "<span class=\"value\">",
                "</span>");

            return value;
        }
    }
}
