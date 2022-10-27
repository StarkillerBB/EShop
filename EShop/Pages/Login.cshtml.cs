using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Interface;
using System.ComponentModel.DataAnnotations;

namespace EShop.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IUserServices _user;

        public LoginModel(IUserServices user)
        {
            _user = user;
        }

        [BindProperty]
        [Required(ErrorMessage = "Brugernavn skal udfyldes")]
        public string Username { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Adgangskode skal udfyldes"), DataType(DataType.Password)]
        public string Password { get; set; }
        [BindProperty]
        public bool FailedLogin { get; set; }


        public IActionResult OnGet()
        {
            int? logout = HttpContext.Session.GetInt32("UserID");
            if (logout != null)
            {
                HttpContext.Session.Remove("RoleID");
                HttpContext.Session.Remove("UserID");
                return RedirectToPage("/Login");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var user = _user.GetUserLogin(Username, Password);

                if (user != null)
                {
                    HttpContext.Session.SetInt32("RoleID", user.RoleId);
                    HttpContext.Session.SetInt32("UserID", user.ID);

                    return RedirectToPage("/Index");
                }
                else
                {
                    FailedLogin = true;
                    return Page();
                }
            }
            return Page();
        }
    }
}
