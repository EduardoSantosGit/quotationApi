using Microsoft.AspNetCore.Mvc;
using Services.markets.WorldMarkets.Domain.Services;
using System.Threading.Tasks;

namespace Services.markets.WorldMarkets.Api.Controllers
{
    [Route("api/v1/markets/")]
    public class WorldMarketsController : Controller
    {
        private WorldMarketsService _worldService;

        public WorldMarketsController(WorldMarketsService worldService)
        {
            _worldService = worldService;
        }

        [HttpGet("world")]
        public async Task<JsonResult> GetWorldsMarkets()
        {
            var values = await _worldService.GetValuesWorldMarkets();            
            return Json(values);
        }
       
    }
}
