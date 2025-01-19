using ECommerceOrderManagementAPI.DTOs.OrderProductDTOs;

namespace ECommerceOrderManagementAPI.DTOs.OrderDTOs
{
    public class GetOrderDTO
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public decimal TotalAmount { get; set; }
        public List<GetOrderProductsDTO> OrderProducts { get; set; }

    }

}
