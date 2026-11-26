using kaucjarz_api.Models;
using Microsoft.EntityFrameworkCore;

namespace kaucjarz_api;

public class AppDBContext(DbContextOptions<AppDBContext> options):DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .Property(u => u.role)
            .HasConversion<string>(); // zamienia UserRole.USER <-> "USER" w Postgresie
    }
    public DbSet<User> Users { get; set; }
}
