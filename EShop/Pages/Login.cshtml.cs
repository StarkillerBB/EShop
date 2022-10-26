using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Interface;

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
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public string ErrorMessage { get; set; }


        public void OnGet()
        {
        }

        public void OnPost()
        {
           var user = _user.GetUserLogin(Username, Password);

            if (user != null)
            {
                HttpContext.Session.SetInt32("RoleID", user.RoleId);
                HttpContext.Session.SetInt32("UserID", user.ID);
            }
            else
            {
                ErrorMessage = "Forkert brugernavn eller adgangskode.";   
            }
        }
    }
}
