using DevsonMotors.Domains;
using DevsonMotors.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using static DevsonMotors.Domains.ProductService;

namespace DevsonMotors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductsService _productService;
        public ProductController(IProductsService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllProduct()
        {
            try
            {
                var product = _productService.GetProductList();
                if(product == null) return NotFound();
                return Ok(product);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("[action]/id")]
        public IActionResult GetProductById(int ProductId)
        {
            try
            {
                var products = _productService.GetProductById(ProductId);
                if(products == null) return NotFound();
                return Ok(products);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpPost]
        [Route("[action]")]
        public IActionResult SaveProduct(Product product)
        {
            try
            {
                var model = _productService.SaveProduct(product);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("[action]/id")]
        public IActionResult DeleteProduct(int ProductId)
        {
            try
            {
                var model = _productService.DeleteProduct(ProductId); 
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
