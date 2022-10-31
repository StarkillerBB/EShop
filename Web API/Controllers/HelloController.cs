using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public IActionResult Hello(string name)
        {
            if (name.ToLower() == "Benjamin")
            {
                return StatusCode(300);
            }

            return  Ok($"Hello {name}");
        }

        [HttpPost]
        public IActionResult FullName(string firstname, string lastname)
        {
            return Ok($"Hello {firstname} {lastname}");
        }

    }
}
