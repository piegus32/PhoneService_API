using Microsoft.EntityFrameworkCore;
using PhoneService_API.Models;

namespace PhoneService_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        public DbSet<Product> Product { get; set; }

        public DbSet<Repair> Repair { get; set; }

        public DbSet<Client> Client { get; set; }

        public DbSet<User> User { get; set; }
    }
}