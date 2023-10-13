using Microsoft.EntityFrameworkCore;
using MvcTire.Models;

namespace MvcMovie.Data
{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext(DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }

        public DbSet<Tire> Tire { get; set; }
    }
}
