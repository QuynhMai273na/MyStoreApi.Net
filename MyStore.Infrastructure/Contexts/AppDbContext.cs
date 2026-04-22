using Microsoft.EntityFrameworkCore;
using MyStore.Domain.Entities;

namespace MyStore.Infrastructure.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Product> Products => Set<Product>();
}