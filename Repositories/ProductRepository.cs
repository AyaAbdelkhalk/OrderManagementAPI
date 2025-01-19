using ECommerceOrderManagementAPI.DTOs.ProductDTOs;
using ECommerceOrderManagementAPI.Interfaces;
using ECommerceOrderManagementAPI.Models;

namespace ECommerceOrderManagementAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDBContext _context;
        public ProductRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<CreateProductsDTO> AddProduct(CreateProductsDTO productdto)
        {
            var product = new Product
            {
                Name = productdto.Name,
                Price = productdto.Price,
                AvailableQuantity = productdto.AvailableQuantity
            };
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return productdto;

        }

        public async Task<List<ProductsDetailsDTO>> GetAllProducts()
        {
            var products = _context.Products.ToList();
            List<ProductsDetailsDTO> productsDetails = new List<ProductsDetailsDTO>();
            foreach (var product in products)
            {
                productsDetails.Add(new ProductsDetailsDTO
                {
                    ID = product.ID,
                    Name = product.Name,
                    Price = product.Price,
                    AvailableQuantity = product.AvailableQuantity
                });
            }
            return productsDetails;

        }
    }
}
