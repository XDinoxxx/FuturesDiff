using Shared.Models;

namespace StorageService.Mapping;

public class CandleDiffmapper
{
    public static CandleDiffDb Map(CandleDiff candle)
    {
        return new CandleDiffDb
        {
            Time = DateTimeOffset.FromUnixTimeMilliseconds(candle.Time).UtcDateTime,
            CloseDiff = candle.CloseDiff
        };
    }

    public static List<CandleDiffDb> MapList(List<CandleDiff> candles)
    {
        return candles.Select(Map).ToList();
    }
}
