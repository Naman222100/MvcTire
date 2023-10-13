using Microsoft.EntityFrameworkCore;
using MvcTire.Models;

namespace MvcTire.Data
{
    public class MvcTireContext : DbContext
    {
        public MvcTireContext(DbContextOptions<MvcTireContext> options)
            : base(options)
        {
        }

        public DbSet<Tire> Tire { get; set; }
    }
}
