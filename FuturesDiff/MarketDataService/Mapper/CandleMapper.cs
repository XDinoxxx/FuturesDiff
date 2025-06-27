using Shared.Models;
using System.Text.Json;

namespace MarketDataService.Mapper;

public class CandleMapper
{
    public static CandleData MapFromApi(JsonElement item)
    {
        return new CandleData
        {
            OpenTime = item[0].GetInt64(),
            Open = decimal.Parse(item[1].GetString(), System.Globalization.CultureInfo.InvariantCulture),
            High = decimal.Parse(item[2].GetString(), System.Globalization.CultureInfo.InvariantCulture),
            Low = decimal.Parse(item[3].GetString(), System.Globalization.CultureInfo.InvariantCulture),
            Close = decimal.Parse(item[4].GetString(), System.Globalization.CultureInfo.InvariantCulture),
            CloseTime = item[6].GetInt64()
        };
    }
}
