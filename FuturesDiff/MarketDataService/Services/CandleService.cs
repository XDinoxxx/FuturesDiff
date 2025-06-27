using MarketDataService.Mapper;
using Shared.Models;
using System.Text.Json;

namespace MarketDataService.Services;
public class CandleService
{
    private readonly HttpClient _client;

    public CandleService(HttpClient client)
    {
        _client = client;
    }

    public async Task<List<CandleData>> GetKlinesAsync(string pair, string interval, int limit)
    {
        var url = $"https://fapi.binance.com/fapi/v1/klines?symbol={pair}&interval={interval}&limit={limit}";
        var responce = await _client.GetAsync(url);
        responce.EnsureSuccessStatusCode();

        var content = await responce.Content.ReadAsStringAsync();
        var json = JsonSerializer.Deserialize<JsonElement>(content);

        return json.EnumerateArray().Select(CandleMapper.MapFromApi)
                                .ToList();
    }
}
