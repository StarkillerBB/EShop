using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ServiceLayer.Interface;
using ServiceLayer.Services;
using System.Reflection;
using System.Text.Json.Serialization;
using Web_API.Formatters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers(options =>
//{
//    options.OutputFormatters.Insert(0, new VcardOutputFormatter());
//})
//    .AddXmlSerializerFormatters();

builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<IGenericServices, GenericServices>();

builder.Services.AddDbContext<EShopContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("EShopConn") ?? throw new InvalidOperationException("Connection string 'EShopConn' not found.")));

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo()
    {
        Version = "v1",
        Title = "Eshop API",
        Description = "Simple CRUD API for the Eshop",
        Contact = new OpenApiContact() { Name = "Google", Url = new Uri("Https://google.com") }
    });
    

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFile));
});

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: "AllowSpecificOrigin", policy =>
//    {
//        policy.WithOrigins("https://localhost:7301")
//        .AllowAnyHeader()
//        .AllowAnyMethod();
//    });
//});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging(); //Slå debugging af Webassembly til i Development
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.

app.UseBlazorFrameworkFiles(); // Sørger for at blazor webassembly appen kan loade de frameworks (DLL) den skal bruge for at køre i browseren 

app.UseStaticFiles(); //loader statiske filer fx billeder fra serveren

//app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("index.html");  // setter endpoint til index.html

app.Run();
