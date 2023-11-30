using BlazorServer.FactoryPatternExample.Data;
using BlazorServer.FactoryPatternExample.Infrastructure;
using BlazorServer.FactoryPatternExample.Repositories.Orders;
using BlazorServer.FactoryPatternExample.Repositories.Products;
using BlazorServer.FactoryPatternExample.Repositories.States;
using BlazorServer.FactoryPatternExample.Services.Orders;
using BlazorServer.FactoryPatternExample.Services.Products;
using BlazorServer.FactoryPatternExample.Services.States;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddTransient<IStateRepository, StateRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();

builder.Services.AddTransient<IStateService, StateService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IProductService, ProductService>();

builder.Services.AddDbContext<FactoryPatternExampleContext>(
    opt => opt.UseSqlite(builder.Configuration.GetConnectionString("FactoryPattern")));

var app = builder.Build();

await EnsureDbIsMigrated(app.Services);

async Task EnsureDbIsMigrated(IServiceProvider services)
{
    using var scope = services.CreateScope();
    using var ctx = scope.ServiceProvider.GetService<FactoryPatternExampleContext>();
    if (ctx != null)
    {
        await ctx.Database.MigrateAsync();
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
