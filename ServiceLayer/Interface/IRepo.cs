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
        List<Types> GetAllTypes();
        List<Roles> GetAllRoles();

    }
}
