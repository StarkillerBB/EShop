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
        void UpdateUser<T>(T entry) where T : class;
        void DeleteUser<T>(T entry) where T : class;

        List<Product> GetAllProducts();
        List<Types> GetAllTypes();
        List<Roles> GetAllRoles();

    }
}
