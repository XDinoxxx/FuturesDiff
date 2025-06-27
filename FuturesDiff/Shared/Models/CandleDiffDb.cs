using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

[Table("Candles")]
public class CandleDiffDb
{
    public int Id { get; set; }
    public DateTime Time { get; set; }
    public decimal CloseDiff { get; set; }
}
