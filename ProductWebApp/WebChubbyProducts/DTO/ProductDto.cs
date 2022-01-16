namespace WebChubbyProducts.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProductDto
    {
        /// <summary>
        /// Identificador
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Descripion
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Categoria
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Precio
        /// </summary>
        public Double Price { get; set; }

        /// <summary>
        /// Cantidad
        /// </summary>
        public int Quantity { get; set; }
    }
}
