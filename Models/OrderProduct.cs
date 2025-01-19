using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceOrderManagementAPI.Models
{
    public class OrderProduct
    {
        public int Id { get; set; }
        public int OrderID { get; set; }
        public Order Order { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int RequiredQuantity { get; set; } 
    }
}
