using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database
{
    public class MSB_DatabaseFactory : IDesignTimeDbContextFactory<MSB_Database>
    {
        public MSB_Database CreateDbContext(string[] args)
        {
            // Adjust the path to point to the API project's directory
            // ändra blackslash i  \API
            var basePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"../API"));

            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json");

            var configuration = configurationBuilder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<MSB_Database>();
            optionsBuilder.UseMySql(configuration.GetConnectionString("DefaultConnection"),
                new MySqlServerVersion(new Version(8, 3, 0)));

            return new MSB_Database(optionsBuilder.Options);
        }
    }
}
