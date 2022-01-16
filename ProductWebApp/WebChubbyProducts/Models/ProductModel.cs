namespace WebChubbyProducts.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;


    public class ProductModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre Producto es Requerido")]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Nombre Producto")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Desripción es Requerido")]
        [StringLength(100, MinimumLength = 3)]
        [Display(Name = "Desripción")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Categoria es Requerido")]
        [StringLength(20, MinimumLength = 3)]
        [Display(Name = "Categoria")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Precio es Requerido")]
        [Display(Name = "Precio")]
        public Double Price { get; set; }

        [Required(ErrorMessage = "Cantidad es Requerido")]
        [Display(Name = "Cantidad")]
        public int Quantity { get; set; }

    }
}
