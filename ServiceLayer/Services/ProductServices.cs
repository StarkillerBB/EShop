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
        public List<Product> GetAllProductsWithPaginationOrderAsc(int currentPage, int pageSize)
        {
            List<Product> products = GetAllProducts().OrderBy(x => x.Price).ToList();
            return products.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }
        public List<Product> GetAllProductsWithPaginationOrderDesc(int currentPage, int pageSize)
        {
            List<Product> products = GetAllProducts().OrderByDescending(x => x.Price).ToList();
            return products.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }

        public List<Product> GetProductsByName(string search, int currentPage, int pageSize)
        {
            var products = _eShopContext.Product.AsNoTracking();
            products = search != null ? products.Where(x => x.SoftDelete == false).Where(x => x.ProductName.ToLower().Contains(search.ToLower())).Include(x => x.Type) : products;

            return products.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }

        
    }
}
