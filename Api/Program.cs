using Api;
using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Providers;
using Implementation;
using Implementation.Interfaces;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
    

// Add services to the container.
builder.Services.AddSingleton<ICustomerProvider, CustomerProvider>();
builder.Services.AddSingleton<ICustomer, CustomerService>();

builder.Services.AddSingleton<ISalesProvider, SaleProvider>();
builder.Services.AddSingleton<ISales, SalesService>();

builder.Services.AddSingleton<IProductProvider, ProductProvider>();
builder.Services.AddSingleton<IProduct, ProductService>();

builder.Services.AddSingleton<ICityProvider, CityProvider>();
builder.Services.AddSingleton<ICity, CityService>();

builder.Logging.ClearProviders();
builder.Host.UseSerilog((hostingContext, loggerConfiguration) =>
{
    loggerConfiguration
        .ReadFrom.Configuration(hostingContext.Configuration);
}, writeToProviders: true);


builder.Services.AddHostedService<MyMethod>();

var app = builder.Build();

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

app.Run();
