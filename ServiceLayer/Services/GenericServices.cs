using DataLayer;
using ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class GenericServices : IGenericServices
    {

        private readonly EShopContext _eShopContext;

        public GenericServices(EShopContext eShopContext)
        {
            _eShopContext = eShopContext;
        }

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
    }
}
