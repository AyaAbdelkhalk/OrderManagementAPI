using ECommerceOrderManagementAPI.DTOs.OrderProductDTOs;

namespace ECommerceOrderManagementAPI.DTOs.OrderDTOs
{
    public class GetOrderDTO
    {
        public int Id { get; set; }
        public string OrderDate { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
        public List<GetOrderProductsDTO> OrderProducts { get; set; }

    }

}
