using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options) { }
        public DbSet<Address> Addresses{ get; set; }
        public DbSet<Developer> Developers{ get; set; }

    }
}