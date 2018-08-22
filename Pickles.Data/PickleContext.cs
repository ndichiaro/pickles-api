using Microsoft.EntityFrameworkCore;
using Pickles.Data.Models;

namespace Pickles.Data
{
    public class PickleContext : DbContext
    {
        public PickleContext(DbContextOptions<PickleContext> options)
            : base(options)
        { }

        DbSet<PickleType> PickleTypes { get; set; }
        DbSet<Vote> Votes { get; set; }
        DbSet<Voter> Voters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
