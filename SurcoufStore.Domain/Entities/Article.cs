using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurcoufStore.Domain.Entities;

[Table("Articles")]
public class Article : EntityBase
{
    public Article()
        : base(0)
    {
        
    }
    public Article(int id = default, string name = default, Category category = default, int stock = default, double priceBuy = default, double priceSell = default)
        : base(id)
    {
        Name = name;
        Category = category;
        Stock = stock;
        PriceBuy = priceBuy;
        PriceSell = priceSell;
    }
    [MinLength(2)]
    [MaxLength(50)]
    public string Name { get; set; }
    [ForeignKey("CategoryId")]
    public Category Category { get; set; }
    public int Stock { get; set; }
    public double PriceBuy { get; set; }
    public double PriceSell { get; set; }
}