using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuotationApi.domain.services;

namespace QuotationApi.Controllers
{
    [Route("api")]
    public class QuotationController : Controller
    {       
        [HttpGet("quotation/coin")]
        public async Task<IActionResult> GetCoins()
        {
            var quotation = new QuotationService();
            var page = await quotation.GetValues();
            return Ok(page);
        }
        
        [HttpGet("quotation/world")]
        public async Task<IActionResult> GetQuotations()
        {
            var quotation = new QuotationService();
            var page = await quotation.GetValuesQuotation();           
            return Ok(page);
        }
        
        
    }
    
    
}