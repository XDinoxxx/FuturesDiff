using Microsoft.AspNetCore.Mvc;
using StorageService.Services;

namespace StorageService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CandleDiffController : ControllerBase
{
    private readonly CandleDiffService _service;

    public CandleDiffController(CandleDiffService service)
    {
        _service = service;
    }

    [HttpPost("fetch")]
    public async Task<ActionResult> FetchAndSave(
        [FromQuery]string pair1,
        [FromQuery]string pair2,
        [FromQuery]string interval
        )
    {
        var savedCount = await _service.FetchAndSaveAsync(pair1, pair2, interval);

        if (savedCount == 0)
            return BadRequest("No data for saved");

        return Ok("Data saved");
    }

}
