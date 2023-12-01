using System.ComponentModel.DataAnnotations.Schema;

namespace SurcoufStore.Domain.Entities;

[Table("Categories")]
public class Category : EntityBase
{
    public Category()
        : base(0)
    {
        
    }
    public Category(int id, string name, Category? category = default)
        : base(id)
    {
        Name = name;
        if (category is not null)
            Parent = category;
    }
    public string Name { get; set; }
    public Category? Parent { get; set; }
}