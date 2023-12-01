using MediatR;
using SurcoufStore.Domain.Entities;
using SurcoufStore.Infrastructure.Repositories;

namespace SurcoufStore.Application.Commands;

public class AddArticleHandler(IRepository repository) : IRequestHandler<AddArticleCommand, Article>
{
    public async Task<Article> Handle(AddArticleCommand request, CancellationToken cancellationToken)
    {
        if (request.PriceBuy <= 0)
            throw new ArgumentException("PriceBuy (> 0)");
        if (request.PriceSell < request.PriceBuy)
            throw new ArgumentException("ne doit pas être < à PriceBuy");

        var category = repository.GetCategory(request.CategoryId) ?? 
            throw new ArgumentException("La catégorie n'existe pas");

        if (request.Stock < 0)
            throw new ArgumentException("Un stock négatif ?");
        if (request.Name.Length < 2 || request.Name.Length > 50)
            throw new ArgumentException("Nom trop court ou trop long");


        return repository.AddArticle(new Article(0, request.Name, category, request.Stock, request.PriceBuy, request.PriceSell));
    }
}