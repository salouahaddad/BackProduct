using app_productAPI.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace app_productAPI.Data
{
    public class AppDbContext : DbContext
    {
        //entities
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
           
            
        }

       
    }
}
