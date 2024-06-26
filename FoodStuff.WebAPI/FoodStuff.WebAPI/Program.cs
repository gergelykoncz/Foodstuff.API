using FoodStuff.Data;
using FoodStuff.Data.Entities;
using FoodStuff.Data.Repositories;
using FoodStuff.Services.Facades;
using FoodStuff.Services.Providers;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
    options.InstanceName = "FoodStuffInstance";
});

builder.Services.AddSingleton<IDistributedCache, RedisCache>();
builder.Services.AddSingleton<ICacheProvider, CacheProvider>();

builder.Services.AddDbContext<FoodstuffContext>();

builder.Services.AddScoped<IRepository<FoodCategory>, BaseRepository<FoodCategory>>();
builder.Services.AddScoped<IRepository<Food>, BaseRepository<Food>>();

builder.Services.AddScoped<IFoodCategoryFacade, FoodCategoryFacade>();
builder.Services.AddScoped<IFoodFacade, FoodFacade>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("Docker"))
{
    app.UseSwagger();
    app.UseSwaggerUI();
    var dbContext = app.Services.GetService<FoodstuffContext>();
    dbContext.Database.EnsureCreated();
    
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(config =>
{
    config.AllowAnyHeader();
    config.AllowAnyMethod();
    config.AllowAnyOrigin();
});

app.MapControllers();

app.Run();
