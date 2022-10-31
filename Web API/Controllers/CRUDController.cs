using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interface;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRUDController : ControllerBase
    {

        private readonly IProductServices _product;
        public CRUDController(IProductServices product)
        {
            _product = product;
        }
        [HttpGet]
        public IList<Product> GetAllProducts()
        {

            return _product.GetAllProducts();
        }
    }
}
