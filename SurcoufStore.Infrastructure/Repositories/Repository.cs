using Microsoft.EntityFrameworkCore;
using SurcoufStore.Domain.Entities;
using SurcoufStore.Infrastructure.Context;
using SurcoufStore.Infrastructure.Extensions;

namespace SurcoufStore.Infrastructure.Repositories;

public class Repository(AppDbContext context) : IRepository
{
    public IQueryable<Article> GetRemainingArticles(int remainingStock)
    {
        return context.Article.Include(x => x.Category).ThenInclude(y => y.Parent)
            .Where(x => x.Stock <= remainingStock);
    }
    public Article AddArticle(Article article)
    {
        if (article.Id != 0) return article;
        var articleAdded = context.Article.Add(article);
        context.SaveChanges();
        return articleAdded.Entity;
    }

    public Category? GetCategory(int id)
    {
        return context.Category.FirstOrDefault(x => x.Id == id);
    }

    public double GetTotalSellValue()
    {
        return context.Article.Sum(x => x.PriceSell * x.Stock);
    }

    public object GetInventory()
    {
        var rts = context.Category.Select(c => new
        {
            CategoryName = c.Name,
            Articles = context.Article.Where(x => x.Category.Id == c.Id).ToList()
        });
        return rts;
    }
}