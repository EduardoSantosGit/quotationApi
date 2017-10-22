using Services.markets.WorldMarkets.Domain.Common;
using Services.markets.WorldMarkets.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorldMarkets.Domain.Interfaces;

namespace Services.markets.WorldMarkets.Domain.Services
{
    public class WorldMarketsServiceScrap
    {
        private readonly ScrapParser _scrapParser;
        private IWorldMarketServicesApi _worldMarketServicesApi;
        private readonly List<string> _abbreviation;

        public WorldMarketsServiceScrap(
            IWorldMarketServicesApi worldMarketServicesApi,
            ScrapParser scrapParser)
        {
            _scrapParser = scrapParser;
            _worldMarketServicesApi = worldMarketServicesApi;
            _abbreviation = new List<string>(new string[] {
                "BOV^IBOV", "DJI^I\\DJI", "NI^I\\COMP", "FT^UKX", "DBI^DAX",
            "EU^PX1", "EU^N100", "BITI^FTSEMIB", "NIK^N225"});
        }

        public async Task<string> GetScrapWorldMarket()
        {
            var html = await _worldMarketServicesApi.GetPageWorldMarkets();

            var blockMarket =
                _scrapParser.ScrapBlockPage(html, "<div id=\"abrAD_rectangle1\">",
                    "<div id=\"abril_barra_assine_widget-2\"");

            return blockMarket;
        }

        public List<WorldMarket> GetValuesIndexParents(string block)
        {
            var lstWorldMarket = new List<WorldMarket>();
           

            var blockMarkets = "";

            for (var i = 0; i < _abbreviation.Count; i++)
            {
                var worldMarket = new WorldMarket();

                if (i == _abbreviation.Count - 1)
                {
                    blockMarkets = _scrapParser.ScrapBlockPage(
                        block, $"<tr><th colspan=\"2\" class=\"height\"><span class=\"main_title\"><a href=\"p.php?pid=exame_quote&symbol={_abbreviation[i]}",
                        "<span class=\"by\"><a class=\"color_black font_bold\" href=\"http://br.advfn.com\">Cotações e Gráficos fornecidos por ");
                }
                else
                {
                    blockMarkets = _scrapParser.ScrapBlockPage(
                        block, $"<tr><th colspan=\"2\" class=\"height\"><span class=\"main_title\"><a href=\"p.php?pid=exame_quote&symbol={_abbreviation[i]}",
                        $"<th colspan=\"2\" class=\"height\"><span class=\"main_title\"><a href=\"p.php?pid=exame_quote&symbol={_abbreviation[i + 1]}");
                }

                worldMarket.Point = _scrapParser.ScrapBlockPage(
                    blockMarkets, "<td><span>Pontos</span> <span><big>",
                    "</big></span></td>");

                worldMarket.Index = _scrapParser.ScrapBlockPage(
                    blockMarkets, $"</a></span><span class=\"name\"><a href=\"p.php?pid=exame_quote&symbol={_abbreviation[i]}\">",
                    "</a></span></th>	</tr>");

                worldMarket.Hour = _scrapParser.ScrapBlockPage(
                    blockMarkets, "</span><br>Hora ",
                    $"</td>\n\t\t</tr>\n\t\t<tr><td colspan=\"2\"><a href=\"p.php?pid=exame_quote&symbol={_abbreviation[i]}\">");

                worldMarket.Parents = _scrapParser.ScrapBlockPage(
                    blockMarkets, "\"\">",
                    $"</a></span><span class=\"name\"><a href=\"p.php?pid=exame_quote&symbol={_abbreviation[i]}\">");

                var sublockVariation = _scrapParser.ScrapBlockPage(
                    blockMarkets, "<td class=\"info_perc\">",
                    "<br>");

                worldMarket.Variation = _scrapParser.ScrapBlockPage(
                    sublockVariation, "'>",
                    "</span>");

                lstWorldMarket.Add(worldMarket);
            }
            return lstWorldMarket;
        }
    }
}
