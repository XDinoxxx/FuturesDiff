using Shared.Models;
using System.Text.Json;

namespace CalculationService.Services;

public class CalculateService
{
    private readonly HttpClient _client;

    public CalculateService(HttpClient client)
    {
        _client = client;
    }

    public async Task<List<CandleDiff>> CalculateDiffAsync(string pair1, string pair2, string interval)
    {
        var candles1 = await GetCandleAsync(pair1, interval);
        var candles2 = await GetCandleAsync(pair2, interval);

        var diffs = candles1.Zip(candles2, (c1, c2) => new CandleDiff
        {
            Time = c1.CloseTime,
            CloseDiff = c1.Close - c2.Close
        }).ToList();

        return diffs;
    }

    private async Task<List<CandleData>> GetCandleAsync(string pair, string interval)
    {
        var url = $"https://localhost:5000/api/candle?symbol={pair}&interval={interval}";
        var responce = await _client.GetAsync(url);
        responce.EnsureSuccessStatusCode();

        var content = await responce.Content.ReadAsStringAsync();
        var candles = JsonSerializer.Deserialize<List<CandleData>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        return candles ?? new List<CandleData>();
    }
}
