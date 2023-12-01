using MediatR;
using SurcoufStore.Domain.Entities;

namespace SurcoufStore.Application.Commands;

public sealed record AddArticleCommand(string Name, int CategoryId, int Stock, double PriceBuy, double PriceSell) : IRequest<Article>;