using SurcoufStore.Domain.Entities;

namespace SurcoufStore.Infrastructure.Repositories;

public interface IRepository
{
    IQueryable<Article> GetRemainingArticles(int remainingStock);
    Article AddArticle(Article article);
    Category? GetCategory(int id);
    double GetTotalSellValue();
    object GetInventory();
}