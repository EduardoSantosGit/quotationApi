using Microsoft.AspNetCore.Mvc;
using Services.markets.WorldMarkets.Domain.Services;
using System.Threading.Tasks;

namespace Services.markets.WorldMarkets.Api.Controllers
{
    [Route("api/v1/markets/")]
    public class WorldMarketsController : Controller
    {
        [HttpGet("world")]
        public async Task<IActionResult> GetWorldsMarkets()
        {
            var _worldService = new WorldMarketsService();
            var _greaterVariants = new GreaterVariantsService();
            var values = await _worldService.GetValuesWorldMarkets();
            var list = await _greaterVariants.GetValuesGreaterVariants();
            return Ok(values);
        }
       
    }
}
