using System.Collections.Generic;

namespace QuotationApi.domain.models
{
    public class Quotation
    {
        public string Index { get; set; }
        public string Parents { get; set; }
        public string Point { get; set; }
        public string Hour { get; set; }
    }
}