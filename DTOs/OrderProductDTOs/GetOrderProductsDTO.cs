namespace ECommerceOrderManagementAPI.DTOs.OrderProductDTOs
{
    public class GetOrderProductsDTO
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal ItemPrice { get; set; }
    }
}
