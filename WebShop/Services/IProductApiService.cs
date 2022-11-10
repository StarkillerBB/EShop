using DataLayer.Entities;

namespace WebShop.Services
{
    public interface IProductApiService
    {
        Task<List<Product>?> GetAllProductsAsync();
        Task<List<Types>?> GetAllTypesAsync();
        Task<Product> GetSingleProductsAsync(int id);
        void UpdateProductAsync(Product product);
        void CreateProductAsync(Product product);
        void DeleteProductAsync(int id);
    }
}
