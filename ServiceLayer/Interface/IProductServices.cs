using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interface
{
    public interface IProductServices
    {
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        List<Product> GetAllProductsWithPagination(int currentPage, int pageSize);
        List<Product> GetAllProductsWithPaginationOrderDesc(int currentPage, int pageSize);
        List<Product> GetAllProductsWithPaginationOrderAsc(int currentPage, int pageSize);
        List<Product> GetProductsByName(string search, int currentPage, int pageSize);
        int GetCount();
    }
}
