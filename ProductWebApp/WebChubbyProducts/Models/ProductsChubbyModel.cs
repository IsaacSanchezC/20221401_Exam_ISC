namespace WebChubbyProducts.Models
{

    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class ProductsChubbyModel
    {
        public List<WebChubbyProducts.Models.ProductModel> Products { get; set; }

        [Display(Name = "Buscar por nombre")]
        public string Filter { get; set; }
    }
}
