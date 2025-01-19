namespace ECommerceOrderManagementAPI.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public List<Order>? Orders { get; set; }
        public List<OrderProduct>? OrderProducts { get; set; }
    }
}
