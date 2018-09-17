using Microsoft.EntityFrameworkCore;
using Pickles.Data.Models;

namespace Pickles.Data
{
    public class PickleContext : DbContext
    {
        public PickleContext(DbContextOptions<PickleContext> options)
            : base(options)
        { }

        public DbSet<PickleType> PickleTypes { get; set; }
        public DbSet<PickleStyle> PickleStyles { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Voter> Voters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PickleType>().HasData(
                new PickleType { Id = 1, Name = "Dill" },
                new PickleType { Id = 2, Name = "Sweet" },
                new PickleType { Id = 3, Name = "Bread and Butter" },
                new PickleType { Id = 4, Name = "Sour" },
                new PickleType { Id = 5, Name = "Other" },
                new PickleType { Id = 6, Name = "None" }
            );

            modelBuilder.Entity<PickleStyle>().HasData(
                new PickleStyle { Id = 1, Name = "Chips" },
                new PickleStyle { Id = 2, Name = "Gherkins" },
                new PickleStyle { Id = 3, Name = "Halves" },
                new PickleStyle { Id = 4, Name = "Lengthwise Slices" },
                new PickleStyle { Id = 5, Name = "Relish" },
                new PickleStyle { Id = 6, Name = "Speats" },
                new PickleStyle { Id = 7, Name = "Whole" },
                new PickleType { Id = 8, Name = "Other" },
                new PickleType { Id = 9, Name = "None" }
            );
        }
    }
}
