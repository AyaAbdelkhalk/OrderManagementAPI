using ECommerceOrderManagementAPI.DTOs.OrderDTOs;
using ECommerceOrderManagementAPI.Interfaces;
using ECommerceOrderManagementAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceOrderManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpPost]
        public async Task<ActionResult<GetOrderDTO>> CreateOrder(CreateOrderDTO order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _orderRepository.CreateOrder(order);
            if (!result.Item1)
            {
                return BadRequest(result.Item2);
            }
            return result.Item3;

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, string newstatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _orderRepository.UpdateOrder(id, newstatus);
            if (!result)
            {
                return NotFound("there is no order");
            }
            var order = await _orderRepository.GetOrderDetails(id);
            return Ok(order);
        }



        [HttpGet]
        public async Task<IEnumerable<GetOrderDTO>> GetAllOrders(string? SearchStatus)
        {
            return await _orderRepository.GetAllOrders(SearchStatus);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetOrderDTO>> GetOrder(int id)
        {
            var order = await _orderRepository.GetOrderDetails(id);
            if (order == null)
            {
                return NotFound();
            }
            return order;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _orderRepository.DeleteOrder(id);
            return Ok("Order has been deleted");
        }
    }
}
