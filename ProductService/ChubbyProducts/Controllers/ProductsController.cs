using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ChubbyProducts.Data.EFCore;
using ChubbyProducts.Models;

namespace ChubbyProducts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ChubbyController<Product, ProductRepository>
    {
        public ProductsController(ProductRepository repository) : base(repository)
        {

        }
    }
}
