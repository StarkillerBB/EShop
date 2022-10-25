using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class ProductServices : IProductServices
    {
        private readonly EShopContext _eShopContext;

        public ProductServices(EShopContext eShopContext)
        {
            _eShopContext = eShopContext;
        }

        public List<Product> GetAllProducts() => _eShopContext.Product.Where(x => x.SoftDelete == false).Include(x => x.Type).ToList();
        public Product GetProductById(int id) => _eShopContext.Product.Where(x => x.ID == id).FirstOrDefault();
        public List<Product> GetProductByNameSearch(string search) => _eShopContext.Product.Where(x => x.ProductName.Contains(search)).Include(x => x.Type).OrderBy(x => x.TypeID).ToList();
        public int GetCount() => GetAllProducts().Count;

        public List<Product> GetAllProductsWithPagination(int currentPage, int pageSize)
        {
            List<Product> products = GetAllProducts();
            return products.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}
