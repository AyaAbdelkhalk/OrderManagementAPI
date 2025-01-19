using ECommerceOrderManagementAPI.DTOs.ProductDTOs;
using ECommerceOrderManagementAPI.Interfaces;
using ECommerceOrderManagementAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceOrderManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpPost]
        public async Task<ActionResult<CreateProductsDTO>> AddProduct(CreateProductsDTO product)
        {
            var result = await _productRepository.AddProduct(product);
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<List<ProductsDetailsDTO>>> GetAllProducts()
        {
            var result = await _productRepository.GetAllProducts();
            return Ok(result);
        }
    }
}
