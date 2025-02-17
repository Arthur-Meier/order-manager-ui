using System.ComponentModel.DataAnnotations;

namespace OrderManager.Models
{
    public class ItemOrder
    {
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int OrderId { get; set; }

        public required Order Order { get; set; }

        public decimal Total => Price * Quantity; // Valor total do item (Preço Unitário * Quantidade)
    }
}
