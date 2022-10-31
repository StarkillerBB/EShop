using DataLayer;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Interface;
using ServiceLayer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IProductServices, ProductServices>();

builder.Services.AddDbContext<EShopContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("EShopConn") ?? throw new InvalidOperationException("Connection string 'EShopConn' not found.")));


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
