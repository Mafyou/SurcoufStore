using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SurcoufStore.Infrastructure.Context;

namespace SurcoufStore.Infrastructure;
public static class AppDbContextExtensions
{
  public static void AddApplicationDbContext(this IServiceCollection services, string connectionString)
  {
    services.AddDbContext<AppDbContext>(options =>
         options.UseSqlite(connectionString));
  }
}