using be_ecom_shop.Model;
using Microsoft.EntityFrameworkCore;

namespace be_ecom_shop.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext
           (DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
    }
}
