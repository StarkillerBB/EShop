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

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 5; //TODO : Change pagesize
        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));
        [BindProperty]
        public string Search { get; set; }

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
    }
}