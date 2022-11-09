using Blazored.Modal;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebShop;
using WebShop.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<IProductApiService, ProductApiService>();

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient<IProductApiService, ProductApiService>(config => config.BaseAddress = AppConfig.Product_BaseAddress);

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredModal();

await builder.Build().RunAsync();
