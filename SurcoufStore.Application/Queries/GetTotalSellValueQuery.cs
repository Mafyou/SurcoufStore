using MediatR;

namespace SurcoufStore.Application.Queries;

public sealed record GetTotalSellValueQuery() : IRequest<double>;