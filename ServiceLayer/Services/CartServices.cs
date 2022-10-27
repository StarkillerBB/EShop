using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.Services;

namespace ServiceLayer.Services
{
    public class CartServices : ICartServices
    {
        private readonly EShopContext _eShopContext;

        public CartServices(EShopContext eShopContext)
        {
            _eShopContext = eShopContext;
        }

        public int CountUserCart(int id)
        {
            List<Cart> carts = _eShopContext.Cart.Where(x => x.UserId == id).ToList();
            int count = 0;
            foreach (var item in carts)
            {
                count = count + item.Amount;
            }

            return count;
        }

        public List<Cart> GetUserProducts(int userID)
        {
            List<Cart> carts = new();

            var query = _eShopContext.User.Where(x => x.ID == userID)
                            .Include(x => x.Carts.Where(x => x.UserId == x.User.ID))
                            .ThenInclude(x => x.Product).ToList();

            foreach (var user in query)
            {
                foreach (var cartList in user.Carts)
                {
                    Cart cart = new();

                    cart.ID = cartList.ID;
                    cart.Amount = cartList.Amount;
                    cart.User = user;
                    cart.Product = cartList.Product;
                    carts.Add(cart);
                }
            }

            return carts;
        }
        public Cart GetUserProductById(int id) => _eShopContext.Cart.Where(x => x.ID == id).FirstOrDefault();

        public void AddCart(Cart cart)
        {
            Cart? cartExist = _eShopContext.Cart.Where(x => x.ProductId == cart.ProductId).Where(x => x.UserId == cart.UserId).FirstOrDefault();
            if (cartExist != null)
            {
                cartExist.Amount++;
                _eShopContext.Update(cartExist);
            }
            else
            {
                _eShopContext.Add(cart);
            }
            _eShopContext.SaveChanges();
        }
        
    }
}
