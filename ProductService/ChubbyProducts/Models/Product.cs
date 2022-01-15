using System;
using System.ComponentModel.DataAnnotations;
using ChubbyProducts.Data;

namespace ChubbyProducts.Models
{
    public class Product : IEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Category { get; set; }

        [Required]
        public Double Price { get; set; }

        [Required]
        public int Quantity { get; set; }

    }
}
