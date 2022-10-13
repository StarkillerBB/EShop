using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.Interface;
using DataLayer;
using DataLayer.Entities;

namespace ServiceLayer.Repository
{
    public class Repo : IRepo
    {
        private readonly EShopContext _eShopContext;

        public Repo()
        {
            _eShopContext = new EShopContext();
        }
        #region Generic
        public void AddEntry<T>(T entry) where T : class
        {
            _eShopContext.Add(entry);
            _eShopContext.SaveChanges();
        }

        public void UpdateUser<T>(T entry) where T : class
        {

            _eShopContext.Update(entry);
            _eShopContext.SaveChanges();
        }
        public void DeleteUser<T>(T entry) where T : class
        {
            _eShopContext.Remove(entry);
            _eShopContext.SaveChanges();

        }
        #endregion

        #region User

        public User GetUserLogin(string username, string password)
        {
            User localUser = _eShopContext.User.Where(x => x.Username == username).FirstOrDefault();

            if (localUser != null && localUser.Password == password)
            {
                return localUser;
            }

            return null;
        }

        #endregion

        #region Cart

        #endregion

        #region Product
        public List<Product> GetAllProducts() => _eShopContext.Product.Where(x => x.SoftDelete == false).ToList();
        #endregion

        #region Types

        public List<Types> GetAllTypes() => _eShopContext.Type.ToList();
        #endregion

        #region Roles

        public List<Roles> GetAllRoles() => _eShopContext.Role.ToList();

        #endregion
    }
}
