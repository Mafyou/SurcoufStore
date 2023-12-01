using MediatR;
using SurcoufStore.Domain.Entities;
using SurcoufStore.Infrastructure.Repositories;
using System.Collections.Frozen;

namespace SurcoufStore.Application.Queries;

public class GetRemainingArticlesQueryHandler(IRepository repository) : IRequestHandler<GetRemainingArticlesQuery, FrozenSet<Article>>
{
    public async Task<FrozenSet<Article>> Handle(GetRemainingArticlesQuery request, CancellationToken cancellationToken)
    {
        return repository.GetRemainingArticles(request.RemainingStock).ToFrozenSet();
    }
}