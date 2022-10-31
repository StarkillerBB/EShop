using DataLayer;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Interface;
using ServiceLayer.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<IGenericServices, GenericServices>();

builder.Services.AddDbContext<EShopContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("EShopConn") ?? throw new InvalidOperationException("Connection string 'EShopConn' not found.")));

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
