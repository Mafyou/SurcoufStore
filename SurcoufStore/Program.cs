using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using SurcoufStore.Application.Commands;
using SurcoufStore.Application.Queries;
using SurcoufStore.Infrastructure;
using SurcoufStore.Infrastructure.Context;
using SurcoufStore.Infrastructure.Data;
using SurcoufStore.Infrastructure.Repositories;
using System.ComponentModel;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
string? connectionString = builder.Configuration.GetConnectionString("SqliteConnection");
if (string.IsNullOrEmpty(connectionString))
	throw new Exception("SQL Lite connection string not found");
builder.Services.AddApplicationDbContext(connectionString);

builder.Services.AddScoped<IRepository, Repository>();

builder.Services.AddMediatR(o =>
{
	o.RegisterServicesFromAssembly(typeof(GetRemainingArticlesQuery).Assembly);
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1.0", new OpenApiInfo { Title = "Magasin Surcouf", Version = "v1.0" });
});

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v0.1/swagger.json", "Magasin Surcouf");
});


//- Une route qui permet d'ajouter un article
app.MapPost("/addArticle", async (string name, int categoryId, int stock, double priceBuy, double priceSell, [FromServices] IMediator mediator) =>
{
	return await mediator.Send(new AddArticleCommand(name, categoryId, stock, priceBuy, priceSell));
});
// - Une route qui retourne la valeur marchande totale des articles
app.MapGet("/getTotalSellValue", async ([FromServices] IMediator mediator) =>
{
    return await mediator.Send(new GetTotalSellValueQuery());
});
// -Une route qui retourne une arborescence complète des catégories avec les articles à chaque niveau
app.MapGet("/getInventory", async ([FromServices] IMediator mediator) =>
{
    return await mediator.Send(new GetInventoryQuery());
});
// - Une route qui retourne la liste des articles avec un stock <= à une valeur donnée en input (par défaut à 0)
app.MapGet("/getRemainingArticles", async ([DefaultValue(0)]int remainingStock, [FromServices] IMediator mediator) =>
{
    return await mediator.Send(new GetRemainingArticlesQuery(remainingStock));
});

SeedDatabase(app);

app.Run();

static void SeedDatabase(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
	try
	{
		var context = services.GetRequiredService<AppDbContext>();
		context.Database.EnsureCreated();
		SeedData.Initialize(context);
	}
	catch (Exception ex)
	{
		var logger = services.GetRequiredService<ILogger<Program>>();
		logger.LogError(ex, "Error seeding the DB {0}", ex.Message);
	}
}