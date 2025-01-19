namespace ECommerceOrderManagementAPI.Models
{
    public class Order
    {
        public int ID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.pending;
        public List<Product>? Products { get; set; }   
        public List<OrderProduct> OrderProducts { get; set; }
    }
}
