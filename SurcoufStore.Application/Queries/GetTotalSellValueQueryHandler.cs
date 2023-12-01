using MediatR;
using SurcoufStore.Infrastructure.Repositories;

namespace SurcoufStore.Application.Queries;

public class GetTotalSellValueQueryHandler(IRepository repository) : IRequestHandler<GetTotalSellValueQuery, double>
{
    public async Task<double> Handle(GetTotalSellValueQuery request, CancellationToken cancellationToken)
    {
        return repository.GetTotalSellValue();
    }
}