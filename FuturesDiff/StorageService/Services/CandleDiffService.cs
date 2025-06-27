using StorageService.Data;

namespace StorageService.Services;

public class CandleDiffService
{
    private readonly AppDbContext _context;
    private readonly FetcherService _service;

    public CandleDiffService(AppDbContext context, FetcherService service)
    {
        _context = context;
        _service = service;
    }

    public async Task<int> FetchAndSaveAsync(string pair1, string pair2, string interval)
    {
        var diffs = await _service.FetchAsync(pair1, pair2, interval);

        if (diffs.Count == 0)
            return 0;

        await _context.Candles.AddRangeAsync(diffs);
        await _context.SaveChangesAsync();

        return diffs.Count;
    }
}
