using Infrastructure.Database;
using Infrastructure.Repositories.DriverRepo;
using Infrastructure.Repositories.EmployeeRepo;
using Infrastructure.Repositories.AddressRepo;
using Infrastructure.Repositories.BoxRepo;
using Infrastructure.Repositories.OrderRepo;
using Infrastructure.Repositories.ShelfRepo;
using Infrastructure.Repositories.UserRepo;
using Infrastructure.Repositories.WarehouseRepo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IDriverRepository, DriverRepository>();

            services.AddDbContext<MSB_Database>(options =>
                   options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
                       new MySqlServerVersion(new Version(8, 3, 0))));
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IWarehouseRepository, WarehouseRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IShelfRepository, ShelfRepository>();
            services.AddScoped<IBoxRepository, BoxRepository>();

            services.AddDbContext<MSB_Database>(options =>
                   options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
                       new MySqlServerVersion(new Version(8, 0, 21)))
                   .EnableSensitiveDataLogging()

            );

            return services;

        }
    }
}
