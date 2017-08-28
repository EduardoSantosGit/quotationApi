using System.Collections.Generic;
using System.Threading.Tasks;
using QuotationApi.domain.models;
using QuotationApi.domain.services.api;

namespace QuotationApi.domain.services
{
    public class QuotationServiceScrap
    {    
        private readonly ScrapService _scrapService;
        private QuotatioServicesApi _quotationServicesApi;

        public QuotationServiceScrap()
        {
            _scrapService = new ScrapService();
        }

        public async Task<string> GetScrapCoins()
        {
            _quotationServicesApi = new QuotatioServicesApi();
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
        
        public async Task<string> GetScrapQuotation()
        {
            _quotationServicesApi = new QuotatioServicesApi();
            var html = await _quotationServicesApi.GetPageQuotaton();

            var blockQuotation = 
                _scrapService.ScrapBlockPage(html, "<div id=\"abrAD_rectangle1\">", 
                    "<div id=\"abril_barra_assine_widget-2\"");
         
            return blockQuotation;
        }

        public List<Quotation> GetValuesIndexParents(string block)
        {    
            
            var lstQuotation = new List<Quotation>();
            var quotation = new Quotation();
            
            var blockIbovespa = _scrapService.ScrapBlockPage(
                block, "<tr><th colspan=\"2\" class=\"height\"><span class=\"main_title\"><a href=\"p.php?pid=exame_quote&symbol=BOV^",
                "<th colspan=\"2\" class=\"height\"><span class=\"main_title\"><a href=\"p.php?pid=exame_quote&symbol=DJI");
            
            quotation.Point = _scrapService.ScrapBlockPage(
                blockIbovespa, "<td><span>Pontos</span> <span><big>",
                "</big></span></td>");
            
            quotation.Index = _scrapService.ScrapBlockPage(
                blockIbovespa, "</a></span><span class=\"name\"><a href=\"p.php?pid=exame_quote&symbol=BOV^IBOV\">",
                "</a></span></th>	</tr>");
            
            quotation.Hour = _scrapService.ScrapBlockPage(
                blockIbovespa, "</span><br>Hora ",
                "</td>\n\t\t</tr>\n\t\t<tr><td colspan=\"2\"><a href=\"p.php?pid=exame_quote&symbol=BOV^IBOV\">");
                
            quotation.Parents = "Brasil";
            
            lstQuotation.Add(quotation);
            
            return lstQuotation;
        }

    }
}