namespace ECommerceOrderManagementAPI.DTOs.ProductDTOs
{
    public class CreateProductsDTO
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int AvailableQuantity { get; set; }
    }
}
