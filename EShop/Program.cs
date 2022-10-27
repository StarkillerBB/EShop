using DataLayer;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Interface;
using ServiceLayer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IGenericServices, GenericServices>();
builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IRepo, Repo>();
builder.Services.AddScoped<ICartServices, CartServices>();

builder.Services.AddSession(options => options.IdleTimeout = TimeSpan.FromMinutes(10));

builder.Services.AddDbContext<EShopContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("EShopConn") ?? throw new InvalidOperationException("Connection string 'EShopConn' not found.")));

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

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
