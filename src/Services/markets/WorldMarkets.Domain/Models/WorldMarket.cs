namespace Services.markets.WorldMarkets.Domain.Models
{
    public class WorldMarket
    {
        public string Index { get; set; }
        public string Parents { get; set; }
        public string Point { get; set; }
        public string Hour { get; set; }
        public string Variation { get; set; }
    }
}
