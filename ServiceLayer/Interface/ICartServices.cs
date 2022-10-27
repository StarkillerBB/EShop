using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interface
{
    public interface ICartServices
    {
        int CountUserCart(int id);
        List<Cart> GetUserProducts(int userID);
        Cart GetUserProductById(int id);
        void AddCart(Cart cart);
    }
}
