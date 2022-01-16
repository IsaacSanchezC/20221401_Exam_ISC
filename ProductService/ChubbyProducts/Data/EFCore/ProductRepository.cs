using ChubbyProducts.Models;
using ChubbyProducts.Models.EFCore;

namespace ChubbyProducts.Data.EFCore
{
    public class ProductRepository : CoreRepository<Product, ChubbyContext>
    {
        public ProductRepository(ChubbyContext context) : base(context)
        {

        }
        // We can add new methods specific to the movie repository here in the future
    }
}
