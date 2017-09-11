using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldMarkets.Domain.Services;

namespace WorldMarkets.Api.Controllers
{
    [Route("api/v1/markets/")]
    public class WorldMarketsController : Controller
    {
        [HttpGet("world")]
        public async Task<IActionResult> GetWorldsMarkets()
        {
            //var _worldService = new WorldMarketsService();
            //var values = await _worldService.GetValuesWorldMarkets();
            return Ok(null);
        }
    }
}
