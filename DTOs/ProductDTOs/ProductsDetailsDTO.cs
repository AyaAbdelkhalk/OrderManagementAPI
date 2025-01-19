namespace ECommerceOrderManagementAPI.DTOs.ProductDTOs
{
    public class ProductsDetailsDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int AvailableQuantity { get; set; }
    }
}
