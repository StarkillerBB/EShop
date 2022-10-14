using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.Interface;
using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

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

        public void UpdateEntry<T>(T entry) where T : class
        {

            _eShopContext.Update(entry);
            _eShopContext.SaveChanges();
        }
        public void DeleteEntry<T>(T entry) where T : class
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
        public List<Product> GetAllProducts() => _eShopContext.Product.Where(x => x.SoftDelete == false).Include(x => x.Type).ToList();
        public List<Product> GetAllProductsWithPagination(int pageStart) => _eShopContext.Product.Where(x => x.SoftDelete == false).Include(x => x.Type).OrderBy(x => x.TypeID).Pagination(pageStart, 3).ToList();
        public Product GetProductById(int id) => _eShopContext.Product.Where(x => x.ID == id).FirstOrDefault();
        public List<Product> GetProductByNameSearch(string search) => _eShopContext.Product.Where(x => x.ProductName.Contains(search)).Include(x => x.Type).OrderBy(x => x.TypeID).ToList();
        #endregion

        #region Types

        public List<Types> GetAllTypes() => _eShopContext.Type.ToList();
        #endregion

        #region Roles

        public List<Roles> GetAllRoles() => _eShopContext.Role.ToList();

        #endregion

        #region Paging

        
        #endregion
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
