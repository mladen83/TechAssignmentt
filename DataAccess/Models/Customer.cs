using System.ComponentModel.DataAnnotations;

namespace DataAccessLibrary.Models
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }

        public Guid CityId { get; set; }

        public City? City { get; set; }

        public ICollection<Sale> Sales { get; set; } = null!;
    }
}
