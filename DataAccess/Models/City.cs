﻿using System.ComponentModel.DataAnnotations;

namespace DataAccessLibrary.Models
{
    public class City
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }
    }
}
