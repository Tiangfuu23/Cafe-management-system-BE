using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repository;
namespace Cafe_management_system.ContextFactory
{
     public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContextFactory() { }

        public RepositoryContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            var builder = new DbContextOptionsBuilder<RepositoryContext>().UseNpgsql(config.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("Cafe-management-system"));


            return new RepositoryContext(builder.Options);
        }
    }
}
