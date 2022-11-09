using DataLayer.Entities;

namespace WebShop.Services
{
    public interface IProductApiService
    {
        Task<List<Product>?> GetAllProductsAsync();
        void UpdateProductAsync(Product product);
        void CreateProductAsync(Product product);
        void DeleteProductAsync(int id);
    }
}
