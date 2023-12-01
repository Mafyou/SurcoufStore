using Microsoft.EntityFrameworkCore;
using SurcoufStore.Domain.Entities;

namespace SurcoufStore.Infrastructure.Context;

public class AppDbContext : DbContext
{
    public string DbPath { get; }
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
        DbPath = "database.sqlite";
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data source={DbPath}");
        SQLitePCL.Batteries.Init();
    }
    public DbSet<Article> Article { get; set; }
    public DbSet<Category> Category { get; set; }
}