using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Interface;

namespace EShop.Pages
{
    public class IndexModel : PageModel
    {

        private readonly IProductServices _product;
        private readonly ICartServices _cart;

        public IndexModel(IProductServices product, ICartServices cart)
        {
            _product = product;
            _cart = cart;
        }

        [BindProperty(SupportsGet = true)]
        public List<Product> Products { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 6; //TODO : Change pagesize
        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));
        [BindProperty]
        public string Search { get; set; }
        [BindProperty]
        public int ProductID { get; set; }
        public int? UserID { get; set; }
        public Cart Cart { get; set; }

        public void OnGet()
        {
            Products = _product.GetAllProductsWithPagination(CurrentPage, PageSize);
            Count = _product.GetCount();
        }


        public void OnPostSearch() 
        { 
            Products = _product.GetProductsByName(Search, CurrentPage, PageSize);
            Count = _product.GetCount();
        }

        public void OnPostHighToLow()
        {
            Products = _product.GetAllProductsWithPaginationOrderDesc(CurrentPage, PageSize);
            Count = _product.GetCount();
        }

        public void OnPostLowToHigh()
        {
            Products = _product.GetAllProductsWithPaginationOrderAsc(CurrentPage, PageSize);
            Count = _product.GetCount();
        }
        
        public IActionResult OnPostAddToCart()
        {
            UserID = HttpContext.Session.GetInt32("UserID");
            if (UserID == null)
            {
                return RedirectToPage("/Login");
            }

            Cart = new Cart();
            Cart.ProductId = ProductID;
            Cart.UserId = Convert.ToInt32(UserID);
            Cart.Amount = 1;

            _cart.AddCart(Cart);
            OnGet();
            return Page();
        }
    }
}