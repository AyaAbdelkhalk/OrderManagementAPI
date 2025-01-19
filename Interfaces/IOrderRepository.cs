using ECommerceOrderManagementAPI.DTOs.OrderDTOs;
using ECommerceOrderManagementAPI.Models;

namespace ECommerceOrderManagementAPI.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<GetOrderDTO>> GetAllOrders(string? SearchStatus);
        Task<GetOrderDTO> GetOrderDetails(int id);
        Task<(bool, List<string>? result, GetOrderDTO? Order)> CreateOrder(CreateOrderDTO order);
        Task<bool> UpdateOrder(int id, string newstatus);
        Task<bool> DeleteOrder(int id);
    }
}
