using ECommerceOrderManagementAPI.Models;

namespace ECommerceOrderManagementAPI.Helpers
{
    public static class OrderExtensions
    {
        public static decimal CalculateTotalAmount(this Order order)
        {
            decimal totalAmount = 0;
            foreach (var orderProduct in order.OrderProducts)
            {
                totalAmount += orderProduct.Product.Price * orderProduct.RequiredQuantity;
            }
            return totalAmount;
        }
    }
}
