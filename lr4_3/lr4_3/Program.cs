using lr4_3.Repositories.Implementations;
using lr4_3.Repositories.Interfaces;
using lr4_3.Services.Implementations;
using lr4_3.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


var builder = WebApplication.CreateBuilder(args);

// Controllers + Enum serialization
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(
            new System.Text.Json.Serialization.JsonStringEnumConverter());
    });

// Swagger (для всіх середовищ, у т.ч. Railway)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ---------- REPOSITORIES ----------
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();
builder.Services.AddScoped<IMenuItemRepository, MenuItemRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

// ---------- SERVICES ----------
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRestaurantService, RestaurantService>();
builder.Services.AddScoped<IMenuItemService, MenuItemService>();
builder.Services.AddScoped<IOrderService, OrderService>();

var app = builder.Build();

// ❗ Railway НЕ ПЕРЕДАЄ HTTPS → редірект повністю вимикаємо
// app.UseHttpsRedirection();
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

// Swagger доступний завжди
app.UseSwagger();
app.UseSwaggerUI();

// Routing
app.MapControllers();

app.Run();