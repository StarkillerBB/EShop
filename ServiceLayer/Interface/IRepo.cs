using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interface
{
    public interface IRepo
    {

        void AddEntry<T>(T entry) where T : class;
        void UpdateEntry<T>(T entry) where T : class;
        void DeleteEntry<T>(T entry) where T : class;

        List<Product> GetAllProducts();
        Product GetProductById(int id);
        List<Types> GetAllTypes();
        List<Roles> GetAllRoles();

        List<Product> GetAllProductsWithPagination(int pageStart);
        List<Product> GetProductByNameSearch(string search);

    }
}
