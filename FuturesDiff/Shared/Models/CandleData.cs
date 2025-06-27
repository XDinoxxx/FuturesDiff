﻿namespace Shared.Models;
public class CandleData
{
    public long OpenTime { get; set; }
    public decimal Open { get; set; }
    public decimal High { get; set; }
    public decimal Low { get; set; }
    public decimal Close { get; set; }
    public long CloseTime { get; set; }
}
