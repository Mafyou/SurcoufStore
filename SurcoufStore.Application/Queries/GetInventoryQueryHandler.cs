using MediatR;
using SurcoufStore.Infrastructure.Repositories;

namespace SurcoufStore.Application.Queries;

public class GetInventoryQueryHandler(IRepository repository) : IRequestHandler<GetInventoryQuery, object>
{
    public async Task<object> Handle(GetInventoryQuery request, CancellationToken cancellationToken)
    {
        return repository.GetInventory();
    }
}