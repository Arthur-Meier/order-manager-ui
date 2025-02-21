using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderManager.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public required string ProductName { get; set; }

        [Required]
        public required decimal CostPrice { get; set; }

        [Required]
        public required decimal ProfitPercentage { get; set; }

        public string? Description { get; set; }

        public int Quantity { get; set; }

        public byte[]? Image { get; set; }
    }
}
