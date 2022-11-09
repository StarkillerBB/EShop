
using DataLayer.Entities;
using System.Net.Http.Json;

namespace WebShop.Services
{
    public class ProductApiService : IProductApiService
    {
        private readonly HttpClient _HttpClient;

        public ProductApiService(HttpClient httpClient)
        {
            _HttpClient = httpClient;
        }

        public async Task<List<Product>?> GetAllProductsAsync()
        {
            var items = await _HttpClient.GetFromJsonAsync<List<Product>>("api/CRUD");

            if (items != null)
            {
                return items;
            }
            return null;
        }

        public async void UpdateProductAsync(Product product)
        {
            await _HttpClient.PutAsJsonAsync<Product>("api/CRUD", product);
        }

        public async void CreateProductAsync(Product product)
        {
            await _HttpClient.PostAsJsonAsync<Product>("api/CRUD", product);
        }

        public async void DeleteProductAsync(int id)
        {
            await _HttpClient.DeleteAsync($"api/CRUD?id={id}");
        }
    }
}
