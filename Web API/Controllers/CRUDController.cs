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
        private readonly IGenericServices _generic;
        public CRUDController(IProductServices product, IGenericServices generic)
        {
            _product = product;
            _generic = generic;
        }
        [HttpGet]
        public List<Product> GetAllProducts() => _product.GetAllProducts();

        [HttpPut]
        public string Edit(Product product)
        {
            _generic.UpdateEntry(product);
            return "Object opdateret.";
        }
    }
}
