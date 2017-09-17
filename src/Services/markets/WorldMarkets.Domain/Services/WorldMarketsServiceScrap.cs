﻿using Services.markets.WorldMarkets.Domain.Common;
using Services.markets.WorldMarkets.Domain.Models;
using Services.markets.WorldMarkets.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.markets.WorldMarkets.Domain.Services
{
    public class WorldMarketsServiceScrap
    {
        private readonly ScrapParser _scrapParser;
        private WorldMarketServicesApi _worldMarketServicesApi;

        public WorldMarketsServiceScrap()
        {
            _scrapParser = new ScrapParser();
        }

        public async Task<string> GetScrapWorldMarket()
        {
            _worldMarketServicesApi = new WorldMarketServicesApi();
            var html = await _worldMarketServicesApi.GetPageWorldMarkets();

            var blockMarket =
                _scrapParser.ScrapBlockPage(html, "<div id=\"abrAD_rectangle1\">",
                    "<div id=\"abril_barra_assine_widget-2\"");

            return blockMarket;
        }

        public List<WorldMarket> GetValuesIndexParents(string block)
        {
            var lstWorldMarket = new List<WorldMarket>();
            var worldMarket = new WorldMarket();

            var blockIbovespa = _scrapParser.ScrapBlockPage(
                block, "<tr><th colspan=\"2\" class=\"height\"><span class=\"main_title\"><a href=\"p.php?pid=exame_quote&symbol=BOV^",
                "<th colspan=\"2\" class=\"height\"><span class=\"main_title\"><a href=\"p.php?pid=exame_quote&symbol=DJI");

            worldMarket.Point = _scrapParser.ScrapBlockPage(
                blockIbovespa, "<td><span>Pontos</span> <span><big>",
                "</big></span></td>");

            worldMarket.Index = _scrapParser.ScrapBlockPage(
                blockIbovespa, "</a></span><span class=\"name\"><a href=\"p.php?pid=exame_quote&symbol=BOV^IBOV\">",
                "</a></span></th>	</tr>");

            worldMarket.Hour = _scrapParser.ScrapBlockPage(
                blockIbovespa, "</span><br>Hora ",
                "</td>\n\t\t</tr>\n\t\t<tr><td colspan=\"2\"><a href=\"p.php?pid=exame_quote&symbol=BOV^IBOV\">");

            worldMarket.Parents = "Brasil";

            lstWorldMarket.Add(worldMarket);

            return lstWorldMarket;
        }
    }
}
