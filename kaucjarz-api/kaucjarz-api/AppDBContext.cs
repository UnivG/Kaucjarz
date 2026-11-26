using kaucjarz_api.Models;
using Microsoft.EntityFrameworkCore;

namespace kaucjarz_api;

public class AppDBContext(DbContextOptions<AppDBContext> options):DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .Property(u => u.role)
            .HasConversion<string>();
        modelBuilder.Entity<Order>()
        .Property(o => o.status)
        .HasConversion<string>();
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
}
