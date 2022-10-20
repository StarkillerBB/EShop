using DataLayer;
using DataLayer.Entities;
using ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class UserServices : IUserServices
    {
        private readonly EShopContext _eShopContext;

        public UserServices(EShopContext eShopContext)
        {
            _eShopContext = eShopContext;
        }

        public User GetUserLogin(string username, string password)
        {
            User localUser = _eShopContext.User.Where(x => x.Username == username).FirstOrDefault();

            if (localUser != null && localUser.Password == password)
            {
                return localUser;
            }

            return null;
        }
    }
}
