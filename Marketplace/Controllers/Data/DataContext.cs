using Microsoft.EntityFrameworkCore;

namespace Marketplace.Controllers.Data
{
    public class DataContext : DbContext
    { 
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Phone> Phones { get; set; }
    }
}
