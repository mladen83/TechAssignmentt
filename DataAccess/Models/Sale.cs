using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLibrary.Models
{
    public class Sale
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid CustomerId { get; set; }

        [Required]
        public Guid ProductId { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal PricePerPiece { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime DateOfSale { get; set; }

        [Required]
        public Product SaleProduct { get; set; } = new Product();
    }
}
