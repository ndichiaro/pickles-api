using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Pickles.Data
{
    public class PickleContextFactory : IDesignTimeDbContextFactory<PickleContext>
    {
        public PickleContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<PickleContext>();
            builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PickleDatabase;Trusted_Connection=True;");
            return new PickleContext(builder.Options);
        }
    }
}
