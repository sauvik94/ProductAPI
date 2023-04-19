using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Models;
using ProductAPI.Services;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_productService.GetProducts());
        }


        [HttpGet("{id}")]
        public IActionResult GetProduct(string id)
        {
            return Ok(_productService.GetProduct(id));
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            int rowsAffected= _productService.AddProduct(product);
            if (rowsAffected>0)
                return Ok("Added");
            else return Ok("Error occured");
        }

    }
}
