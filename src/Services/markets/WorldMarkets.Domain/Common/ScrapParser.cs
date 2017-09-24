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

        public string ClippingBlock(string block, string indexOn, string indexLast)
        {
            var firstIndex = block.IndexOf(indexOn);
            var lastIndex = block.IndexOf(indexLast);
            var count = lastIndex - firstIndex;
            var resultBlock = block.Remove(firstIndex, count);
            return resultBlock;
        }
    }
}