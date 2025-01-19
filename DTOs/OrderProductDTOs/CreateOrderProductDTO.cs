namespace ECommerceOrderManagementAPI.DTOs.OrderProductDTOs
{
    public class CreateOrderProductDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int RequiredQuantity { get; set; } = 1;
    }
}
