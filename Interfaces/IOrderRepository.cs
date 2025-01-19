using ECommerceOrderManagementAPI.Models;

namespace ECommerceOrderManagementAPI.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrders();
        //Task<Order> GetOrder(int id);
        //Task<Order> CreateOrder(Order order);
        //Task<Order> UpdateOrder(Order order);
        Task<bool> DeleteOrder(int id);
    }
}
