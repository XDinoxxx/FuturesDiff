using CalculationService.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace CalculationService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CalculateController : ControllerBase
{
    private readonly CalculateService _service;

    public CalculateController(CalculateService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<CandleDiff>>> GetSpreadAsync(
        [FromQuery]string pair1,
        [FromQuery]string pair2,
        [FromQuery]string interval
        )
    {
        var results = await _service.CalculateDiffAsync(pair1, pair2, interval);
        return Ok(results);
    }
}
