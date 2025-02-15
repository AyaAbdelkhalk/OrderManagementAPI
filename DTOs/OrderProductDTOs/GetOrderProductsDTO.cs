﻿namespace ECommerceOrderManagementAPI.DTOs.OrderProductDTOs
{
    public class GetOrderProductsDTO
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int RequiredQuantity { get; set; } = 1;
        public decimal UnitPrice { get; set; }
    }
}
