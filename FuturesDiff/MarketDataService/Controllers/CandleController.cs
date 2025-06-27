using MarketDataService.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace MarketDataService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CandleController : ControllerBase
{
    private readonly CandleService _service;

    public CandleController(CandleService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<CandleData>>> GetCandleAsync(
        [FromQuery]string symbol,
        [FromQuery]string interval,
        [FromQuery]int limit = 90)
    {
        var candles = await _service.GetKlinesAsync(symbol, interval, limit);
        return Ok(candles);
    }
}
