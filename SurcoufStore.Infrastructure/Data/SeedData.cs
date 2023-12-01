using SurcoufStore.Domain.Entities;
using SurcoufStore.Infrastructure.Context;

namespace SurcoufStore.Infrastructure.Data;

public static class SeedData
{
    private static readonly Category highTech = new(1, "High Tech");
    private static readonly Category telephonie = new(2, "Téléphonie", highTech);
    private static readonly Category android = new(3, "Android", telephonie);
    private static readonly Category ios = new(4, "Android", telephonie);
    private static readonly Category pc = new(5, "PC", highTech);
    private static readonly Category ecrans = new(6, "Ecrans", highTech);
    private static readonly Category ecrans_pc = new(7, "Ecrans PC", ecrans);
    private static readonly Category ecrans_tv = new(8, "Ecrans TV", ecrans);
    private static readonly Category electromenager = new(9, "Electroménager");
    private static readonly Category frigo = new(10, "Frigo", electromenager);
    private static readonly Category lave_vaiselle = new(11, "Lave vaisselle", electromenager);

    private static readonly List<Article> articles =
        [
            new Article(1, "Samsung S20", android, 10, 600, 800),
            new Article(2, "Xiaomi", android, 10, 250, 299.99),
            new Article(3, "iPhone 14", ios, 8, 900, 1200),
            new Article(4, "Pc Gamer", pc, 2, 1800, 2000),
            new Article(5, "Kindle", ecrans, 0, 150, 180),
            new Article(6, "Lenovo 27 pouces", ecrans_pc, 3, 250, 330),
            new Article(7, "Samsung The Frame", ecrans_tv, 10, 1400, 1500),
            new Article(8, "Frigo Electrolux", frigo, 5, 800, 1000),
            new Article(9, "Whirlpool", lave_vaiselle, 5, 450, 550)
        ];
    public static void Initialize(AppDbContext context)
    {
        if (context.Category.Any() || context.Article.Any())
            return; // DB has been seeded
        populateData(context);
    }
    private static void populateData(AppDbContext context)
    {
        context.Category.RemoveRange(context.Category);
        context.Article.RemoveRange(context.Article);
        context.SaveChanges();

        context.Category.AddRange([highTech, telephonie, android, ios, pc, ecrans, ecrans_pc, ecrans_tv, electromenager, frigo, lave_vaiselle]);
        context.Article.AddRange(articles);
        context.SaveChanges();
    }
}