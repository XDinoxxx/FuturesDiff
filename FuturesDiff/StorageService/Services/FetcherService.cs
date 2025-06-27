using Shared.Models;
using StorageService.Mapping;

namespace StorageService.Services;

public class FetcherService
{
    private readonly HttpClient _client;

    public FetcherService(HttpClient client)
    {
        _client = client;
    }

    public async Task<List<CandleDiffDb>> FetchAsync(string pair1, string pair2, string interval)
    {
        var url = $"https://localhost:5001/api/Calculate?pair1={pair1}&pair2={pair2}&interval={interval}";
        var raw = await _client.GetFromJsonAsync<List<CandleDiff>>(url);

        return CandleDiffmapper.MapList(raw ?? new List<CandleDiff>());
    }
}
