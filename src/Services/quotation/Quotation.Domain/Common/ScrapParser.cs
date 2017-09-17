﻿namespace Services.quotation.Quotation.Domain.Common
{
    public class ScrapParser
    {

        public string ScrapBlockPage(string html, string indexOn, string indexLast)
        {   
            var fisrtIndex = html.LastIndexOf(indexOn);

            fisrtIndex = fisrtIndex + indexOn.Length;

            var lastIndex = html.IndexOf(indexLast);

            var exit = lastIndex - fisrtIndex;

            var block = html.Substring(fisrtIndex, exit);
            return block;
        }
    }
}