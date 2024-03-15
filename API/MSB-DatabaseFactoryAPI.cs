using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace API
{
    public class MSB_DatabaseFactoryAPI : IDesignTimeDbContextFactory<MSB_Database>
    {
        public MSB_Database CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Make sure this is your API project directory
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var builder = new DbContextOptionsBuilder<MSB_Database>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 21))); // Match your MySQL version

            return new MSB_Database(builder.Options);
        }
    }
}
