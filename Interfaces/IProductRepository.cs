using ECommerceOrderManagementAPI.DTOs.ProductDTOs;
using ECommerceOrderManagementAPI.Models;

namespace ECommerceOrderManagementAPI.Interfaces
{
    public interface IProductRepository
    {
        Task<CreateProductsDTO> AddProduct(CreateProductsDTO product);
        Task<List<ProductsDetailsDTO>> GetAllProducts();
    }
}
