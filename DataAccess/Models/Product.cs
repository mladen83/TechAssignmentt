using System.ComponentModel.DataAnnotations;

namespace DataAccessLibrary.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }

        public ICollection<Sale> ProductSales { get; set; } = null!;
    }
}
