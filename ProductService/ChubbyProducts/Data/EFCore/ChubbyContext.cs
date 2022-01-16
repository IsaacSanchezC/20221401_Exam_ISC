using Microsoft.EntityFrameworkCore;

namespace ChubbyProducts.Models.EFCore
{
    public class ChubbyContext : DbContext
    {
        public ChubbyContext (DbContextOptions<ChubbyContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }

    }
}
