using Api.Apis;
using DataAccess;
using DataAccess.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Shared.Interfaces.IRepository;
using Shared.Interfaces.IService;


var builder = WebApplication.CreateBuilder(args);

// Load MongoDB settings from configuration
builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings"));

// Register MongoDbContext as a singleton
builder.Services.AddSingleton<MongoDbContext>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    return new MongoDbContext(settings);
});

// Register repositories and services
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();







var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapCategoryEndpoints();
app.MapProductEndpoints();
app.MapCustomerEndpoints();
app.MapOrderEndpoints();




app.Run();

