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
    public class TypeServices : ITypeServices
    {
        private readonly EShopContext _eShopContext;

        public TypeServices(EShopContext eShopContext)
        {
            _eShopContext = eShopContext;
        }

        public List<Types> GetAllTypes() => _eShopContext.Type.ToList();
    }
}
