using ECommerceOrderManagementAPI.DTOs.OrderProductDTOs;
using ECommerceOrderManagementAPI.Models;

namespace ECommerceOrderManagementAPI.DTOs.OrderDTOs
{
    public class CreateOrderDTO
    {
        public string Status { get; set; } = "pending";
        public List<CreateOrderProductDTO> OrderProducts { get; set; }

    }
}
