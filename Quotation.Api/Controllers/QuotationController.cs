using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quotation.Domain.Services;

namespace Quotation.Api.Controllers
{
    [Route("api/v1/quotation/")]
    public class QuotationController : Controller
    {
        [HttpGet("coins")]
        public async Task<IActionResult> GetCoins()
        {
            var quotation = new QuotationService();
            var page = await quotation.GetValuesCoins();
            return Ok(page);
        }
    }
}

