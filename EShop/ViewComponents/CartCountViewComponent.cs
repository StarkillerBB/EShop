using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interface;

namespace EShop.ViewComponents
{
    public class CartCountViewComponent : ViewComponent
    {
        private readonly ICartServices _cart;

        public CartCountViewComponent(ICartServices cart)
        {
            _cart = cart;
        }

        public IViewComponentResult Invoke()
        {
            var userID = HttpContext.Session.GetInt32("UserID");
            if (userID != null)
            {
                int count = _cart.CountUserCart(Convert.ToInt32(userID));
                return View(count);
            }
            return View(0);
            
        }
    }
}
