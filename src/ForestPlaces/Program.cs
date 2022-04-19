using Core.Commands;
using Core.Entities;
using Core.Queries;
using DAL;
using DAL.Commands.AreaCommands;
using DAL.Commands.CategoryCommands;
using DAL.Queries.GetAllAreaQueries;
using DAL.Queries.GetAllCategoryQueries;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PlaceContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionStrings")));

builder.Services.AddScoped<IQueryHandler<GetAllCategoriesQuery, IList<Category>>, GetAllCategoriesQueryHandler>();
builder.Services.AddScoped<IQueryHandler<GetAllAreasQuery, IList<Area>>, GetAllAreasQueryHandler>();

builder.Services.AddScoped<ICommandHandler<CreateCategoryCommand>, CreateCategoryCommandHandler>();
builder.Services.AddScoped<ICommandHandler<DeleteCategoryCommand>, DeleteCategoryCommandHandler>();
builder.Services.AddScoped<ICommandHandler<CreateAreaCommand>, CreateAreaCommandHandler>();
builder.Services.AddScoped<ICommandHandler<DeleteAreaCommand>, DeleteAreaCommandHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
