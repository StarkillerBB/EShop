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
        List<Product> GetProductByNameSearch(string search);
        int GetCount();
    }
}
