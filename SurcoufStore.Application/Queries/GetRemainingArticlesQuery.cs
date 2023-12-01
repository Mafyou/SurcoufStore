using MediatR;
using SurcoufStore.Domain.Entities;
using System.Collections.Frozen;

namespace SurcoufStore.Application.Queries;

public sealed record GetRemainingArticlesQuery(int RemainingStock) : IRequest<FrozenSet<Article>>;