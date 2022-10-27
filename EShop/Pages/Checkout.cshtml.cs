using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Interface;

namespace EShop.Pages
{
    public class CheckoutModel : PageModel
    {

        private readonly ICartServices _cart;
        private readonly IGenericServices _generic;
        private readonly IUserServices _user;

        public CheckoutModel(ICartServices cart, IGenericServices generic, IUserServices user)
        {
            _cart = cart;
            _generic = generic;
            _user = user;
        }

        public int? UserID { get; set; }
        [BindProperty]
        public int CartID { get; set; }
        public List<Cart> Carts { get; set; }
        public User User { get; set; }
        public decimal TotalPrice { get; set; }

        public IActionResult OnGet()
        {
            UserID = HttpContext.Session.GetInt32("UserID");

            if (UserID == null)
            {
                return RedirectToPage("/Index");
            }

            Carts = _cart.GetUserProducts(Convert.ToInt32(UserID)).OrderBy(x => x.Product.ProductName).ToList();
            CalculatePrice();

            User = _user.GetUserById(Convert.ToInt32(UserID));
            return Page();
        }

        public void OnPostIncrease()
        {
            Cart cart = _cart.GetUserProductById(CartID);

            cart.Amount++;

            _generic.UpdateEntry(cart);
            OnGet();
        }
        public void OnPostDecrease()
        {
            Cart cart = _cart.GetUserProductById(CartID);

            if (cart.Amount == 1)
            {
                _generic.DeleteEntry(cart);
            }
            else
            {
                cart.Amount--;
                _generic.UpdateEntry(cart);
            }
            OnGet();
        }
        public decimal CalculatePrice()
        {
            foreach (var item in Carts)
            {
                for (int i = 0; i < item.Amount; i++)
                {
                    TotalPrice = item.Product.Price + TotalPrice;
                }
            }

            return TotalPrice;
        }
    }
}
