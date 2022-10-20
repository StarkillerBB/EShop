using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Interface;

namespace EShop.Pages
{
    public class IndexModel : PageModel
    {

        private readonly IProductServices _product;

        public IndexModel(IProductServices product)
        {
            _product = product;
        }

        [BindProperty]
        public List<Product> Products { get; set; }

        public void OnGet()
        {
            Products = _product.GetAllProducts();
        }
    }
}