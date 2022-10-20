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
        public List<Product> GetAllProductsWithPagination(int pageStart) => _eShopContext.Product.Where(x => x.SoftDelete == false).Include(x => x.Type).OrderBy(x => x.TypeID).Pagination(pageStart, 3).ToList();
        public Product GetProductById(int id) => _eShopContext.Product.Where(x => x.ID == id).FirstOrDefault();
        public List<Product> GetProductByNameSearch(string search) => _eShopContext.Product.Where(x => x.ProductName.Contains(search)).Include(x => x.Type).OrderBy(x => x.TypeID).ToList();

    }

    public static class Paging
    {
        public static IQueryable<T> Pagination<T>(this IQueryable<T> query, int pageNumZeroStart, int pageSize)
        {
            if (pageSize == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize), "pageSize cannot be zero.");
            }
            if (pageNumZeroStart != 0)
            {
                query = query.Skip(pageNumZeroStart * pageSize);
            }
            return query.Take(pageSize);
        }
    }
}
