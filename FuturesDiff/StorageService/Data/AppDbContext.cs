using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace StorageService.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<CandleDiffDb> Candles { get; set; } 
}
