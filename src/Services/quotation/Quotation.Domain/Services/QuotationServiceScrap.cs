using Services.quotation.Quotation.Domain.Common;
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
        private readonly ScrapParser _scrapParser;
        private QuotationServicesApi _quotationServicesApi;

        public QuotationServiceScrap()
        {
            _scrapParser = new ScrapParser();
        }

        public async Task<string> GetScrapCoins()
        {
            _quotationServicesApi = new QuotationServicesApi();
            var html = await _quotationServicesApi.GetPageIndex();

            var blockQuotation =
                _scrapParser.ScrapBlockPage(html, "abril_exame_cotacoes_widget-48", "abrAD_button1");

            var blockValuesQuotation =
                _scrapParser.ScrapBlockPage(blockQuotation, "<div class=\"exchange-container\">",
                    "<div class=\"bvsp\">"
            );

            return blockValuesQuotation;
        }

        public string GetValueDolar(string block)
        {
            var blockDolar = _scrapParser.ScrapBlockPage(
                block, "<div class=\"exchange exchange-usd\">",
                "</div>");

            var value = _scrapParser.ScrapBlockPage(
                blockDolar, "<span class=\"value\">",
                "</span>");

            return value;
        }

        public string GetValueEuro(string block)
        {
            var blockEuro = _scrapParser.ScrapBlockPage(
                block, "<div class=\"exchange exchange-eur\">",
                "<div class=\"exchange exchange-selic\">");

            var value = _scrapParser.ScrapBlockPage(
                blockEuro, "<span class=\"value\">",
                "</span>");

            return value;
        }
    }
}
