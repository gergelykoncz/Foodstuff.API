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

builder.Services.AddScoped<IRepository<FoodCategory>, FoodCategoryRepository>();
builder.Services.AddScoped<IFoodCategoryFacade, FoodCategoryFacade>();

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
