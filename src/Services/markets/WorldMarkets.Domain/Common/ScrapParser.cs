namespace Services.markets.WorldMarkets.Domain.Common
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

        public string ClippingBlock(string block, string indexOn, string indexLast, 
            int ignoreCharacterIndex = 0, int ignoreCharacterLast = 0)
        {
            var firstIndex = block.IndexOf(indexOn);
            var lastIndex = block.IndexOf(indexLast);

            if (ignoreCharacterIndex != 0)
            {
                firstIndex = firstIndex + ignoreCharacterIndex;
            }
            if (ignoreCharacterLast != 0)
            {
                lastIndex = lastIndex + ignoreCharacterLast;
            }

            var count = lastIndex - firstIndex;
            var resultBlock = block.Substring(firstIndex, count);
            return resultBlock;
        }
    }
}