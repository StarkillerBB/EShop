using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.Interface;
using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace ServiceLayer.Services
{
    public class Repo : IRepo
    {
        private readonly EShopContext _eShopContext;

        public Repo(EShopContext eShopContext)
        {
            _eShopContext = eShopContext;
        }
        #region Generic
        
        #endregion

        #region User

        

        #endregion

        #region Cart

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

    
}
