using ECommerceOrderManagementAPI.DTOs.OrderDTOs;
using ECommerceOrderManagementAPI.DTOs.OrderProductDTOs;
using ECommerceOrderManagementAPI.Helpers;
using ECommerceOrderManagementAPI.Interfaces;
using ECommerceOrderManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerceOrderManagementAPI.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDBContext _context;
        public OrderRepository(AppDBContext context)
        {
            _context = context;
        }

        #region Create Order
        public async Task<(bool ,List<string>? result,GetOrderDTO? Order)> CreateOrder(CreateOrderDTO order)
        {
            List<string> errors = new List<string>();
            order.Status = order.Status.ToLower();
            var r  = Enum.TryParse(order.Status, out OrderStatus status);
            if (!r)
            {
                return (false, new List<string> { "Invalid Order Status" }, null);
            }
            if (order.OrderProducts.Count == 0)
            {
                errors.Add("Order should have at least one product.");
                return (false, errors, null);
            }
            var newOrder = new Order
            {
                OrderDate = DateTime.Now,
                Status = Enum.Parse<OrderStatus>(order.Status),
                TotalAmount = 0,
                OrderProducts = new List<OrderProduct>()
            };
            if(order.OrderProducts.Count == 0)
            {
                errors.Add("Order should have at least one product.");
                return (false, errors, null);
            }
            foreach (var orderProduct in order.OrderProducts)
            {
                var product = await _context.Products.FindAsync(orderProduct.ProductId);
                if (product == null)
                {
                    errors.Add($"Product {orderProduct.ProductName} not found.");
                    continue;

                }
                if (product.AvailableQuantity < orderProduct.RequiredQuantity)
                {
                    errors.Add($"Product {orderProduct.ProductName} has only {product.AvailableQuantity} available.");
                    continue;

                }
                if (orderProduct.RequiredQuantity <= 0)
                {
                    errors.Add($"Product {orderProduct.ProductName} required quantity should be greater than 0.");
                    continue;

                }
                if (product != null && product.AvailableQuantity>= orderProduct.RequiredQuantity)
                {

                    var newOrderProduct = new OrderProduct();
                    newOrderProduct.ProductID = orderProduct.ProductId;
                    newOrderProduct.OrderID = newOrder.ID;
                    newOrderProduct.RequiredQuantity = orderProduct.RequiredQuantity;
                    newOrder.OrderProducts.Add(newOrderProduct);
                    product.AvailableQuantity -= orderProduct.RequiredQuantity;

                }
                
            }
            if (errors.Count > 0)
            {
                return (false, errors, null);
            }
            _context.Orders.Add(newOrder);
            await _context.SaveChangesAsync();
            var norder = await _context.Orders
                    .Include(o => o.OrderProducts)
                    .ThenInclude(op => op.Product)
                    .FirstOrDefaultAsync(o => o.ID == newOrder.ID);
            newOrder.TotalAmount = norder.CalculateTotalAmount();
            await _context.SaveChangesAsync();
            var id = newOrder.ID;
            var orderdto = await GetOrderDetails(id);
            return (true, null, orderdto);

        }
        #endregion

        #region Update Order status
        public async Task<bool> UpdateOrder(int id, string newstatus)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return false;
            }
            order.Status = Enum.Parse<OrderStatus>(newstatus);
            await _context.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Get
        public async Task<IEnumerable<GetOrderDTO>> GetAllOrders(string? SearchStatus)
        {
            var orders = _context.Orders
                .Include(o => o.OrderProducts)
                .ThenInclude(op => op.Product).AsQueryable();
            if (!string.IsNullOrEmpty(SearchStatus))
            {
                orders = orders.Where(o => o.Status.ToString().ToLower().Contains(SearchStatus.ToLower()));
            }
            List<GetOrderDTO> orderDTOs = new List<GetOrderDTO>();
            foreach (var order in orders)
            {
                var orderDTO = new GetOrderDTO
                {
                    Id = order.ID,
                    OrderDate = order.OrderDate.ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                    Status = Enum.GetName(order.Status) ?? string.Empty,
                    TotalAmount = order.TotalAmount,
                    OrderProducts = order.OrderProducts.Select(op => new GetOrderProductsDTO
                    {
                        Id = op.Id,
                        ProductName = op.Product.Name,
                        RequiredQuantity = op.RequiredQuantity,
                        UnitPrice = op.Product.Price
                    }).ToList()
                };
                orderDTOs.Add(orderDTO);
            }
            return orderDTOs;
        }

        public async Task<GetOrderDTO> GetOrderDetails(int id)
        {
            var order = await _context.Orders.Include(o => o.OrderProducts).ThenInclude(op => op.Product).FirstOrDefaultAsync(o => o.ID == id);
            if (order == null)
            {
                return null;
            }
            var orderDTO = new GetOrderDTO
            {
                Id = order.ID,
                OrderDate = order.OrderDate.ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                Status = Enum.GetName(order.Status) ?? string.Empty,
                TotalAmount = order.TotalAmount,
                OrderProducts = order.OrderProducts.Select(op => new GetOrderProductsDTO
                {
                    Id = op.Id,
                    ProductName = op.Product.Name,
                    RequiredQuantity = op.RequiredQuantity,
                    UnitPrice = op.Product.Price
                }).ToList()
            };
            return orderDTO;
        }
        #endregion

        #region Delete Order
        public async Task<bool> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return false;
            }
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return true;
        } 
        #endregion

    }
}
