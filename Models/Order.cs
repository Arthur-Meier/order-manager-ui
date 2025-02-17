using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderManager.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public int ClientId { get; set; }

        public required Client Client { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public decimal TotalValue { get; set; }

        public List<ItemOrder> Items { get; set; } = new List<ItemOrder>();

        public bool CanBeEdited => OrderDate.AddHours(24) > DateTime.Now;
    }
}
