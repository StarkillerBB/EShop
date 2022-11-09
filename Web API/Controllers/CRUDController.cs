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

        /// <summary>
        /// Get all Products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Product> GetAllProducts() => _product.GetAllProducts();

        [HttpGet]
        [Route("item/{search}")]
        public List<Product> GetAllProductsBySearch(string search) => _product.GetProductByNameSearch(search);

        /// <summary>
        /// Edits a specific product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Edit(Product product)
        {
            try
            {
                _generic.UpdateEntry(product);
            }
            catch (Exception)
            {
                return StatusCode(400);
                
            }

            return Ok("Object opdateret");
        }

        /// <summary>
        /// Creates a products.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(Product product)
        {
            try
            {
                _generic.AddEntry(product);
            }
            catch (Exception)
            {
                return StatusCode(400);
            }
            return Ok("Object opdateret.");
        }

        /// <summary>
        /// Deletes a product from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(int id)
        {

            try
            {
                Product product = _product.GetProductById(id);
                _generic.DeleteEntry(product);
            }
            catch (Exception)
            {
                return StatusCode(400);
            }
            return Ok("Object slettet");
        }
    }
}
