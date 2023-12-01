using MediatR;

namespace SurcoufStore.Application.Queries;

public sealed record GetInventoryQuery() : IRequest<object>;