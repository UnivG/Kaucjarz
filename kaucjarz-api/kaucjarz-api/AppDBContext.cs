using kaucjarz_api.Models;
using Microsoft.EntityFrameworkCore;

namespace kaucjarz_api;

public class AppDBContext(DbContextOptions<AppDBContext> options):DbContext(options)
{
    public DbSet<User> Users { get; set; }
}