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

        public Repo(EShopContext eShopContext)
        {
            _eShopContext = eShopContext;
        }


        #region User

        public void AddUser(User user)
        {
            _eShopContext.Add(user);
            _eShopContext.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            User localUser = _eShopContext.User.Where(x => x.ID == user.ID).FirstOrDefault();

            localUser.FirstName = user.FirstName;
            localUser.LastName = user.LastName;
            localUser.Mail = user.Mail;
            localUser.Phone = user.Phone;
            localUser.Password = user.Password;
            localUser.Username = user.Username;
            localUser.Address = user.Address;
            localUser.ZipCode = user.ZipCode;
            localUser.RoleId = user.RoleId;

            _eShopContext.Update(localUser);
            _eShopContext.SaveChanges();
        }
        #endregion

        #region Cart

        #endregion

        #region Product

        #endregion

        #region Types

        #endregion

        #region Roles

        #endregion
    }
}
