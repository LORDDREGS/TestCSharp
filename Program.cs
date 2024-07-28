using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using Microsoft.Extensions.Options; // Добавьте эту директиву
using TestCSharp.Models;
using TestCSharp.Services;

var builder = WebApplication.CreateBuilder(args);

// Настройка сервисов
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));
builder.Services.AddSingleton<MongoDbService>();

// Добавление поддержки контроллеров с представлениями
builder.Services.AddControllersWithViews();

// Конфигурация MongoDB для каждой коллекции
builder.Services.AddSingleton<IMongoCollection<Plant>>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    var client = new MongoClient(settings.ConnectionString);
    var database = client.GetDatabase(settings.DatabaseName);
    return database.GetCollection<Plant>("plants");
});

builder.Services.AddSingleton<IMongoCollection<Department>>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    var client = new MongoClient(settings.ConnectionString);
    var database = client.GetDatabase(settings.DatabaseName);
    return database.GetCollection<Department>("departments");
});

builder.Services.AddSingleton<IMongoCollection<Position>>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    var client = new MongoClient(settings.ConnectionString);
    var database = client.GetDatabase(settings.DatabaseName);
    return database.GetCollection<Position>("positions");
});

// Добавление конфигурации HTTP конвейера
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
