using Domain.Models.Address;
using Domain.Models.OrderModel;
using Domain.Models.Shelf;
using Domain.Models.UserModel;
using Domain.Models.Warehouse;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
{
    public class MSB_Database : DbContext
    {

        public MSB_Database(DbContextOptions<MSB_Database> options) : base(options) { }

        public virtual DbSet<UserModels> Users { get; set; }
        public virtual DbSet<AddressModel> Addresses { get; set; }
        public virtual DbSet<OrderModel> Orders { get; set; }
        public virtual DbSet<WarehouseModel> Warehouses { get; set; }
        public virtual DbSet<ShelfModel> Shelves { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mock data for UserModels
            var users = new UserModels[]
            {
            new UserModels { UserId = Guid.NewGuid(), Email = "Adam@gmail.com", FirstName = "Adam", LastName = "Andersson", PhoneNumber = 0735097384, PasswordHash = "Adam123" },
            new UserModels { UserId = Guid.NewGuid(), Email = "Bertil@gmail.com", FirstName = "Bertil", LastName = "Bengtsson", PhoneNumber = 0735097384, PasswordHash = "Bertil123" },
            new UserModels { UserId = Guid.NewGuid(), Email = "Cecar@gmail.com", FirstName = "Cecar", LastName = "Citron", PhoneNumber = 0735097384, PasswordHash = "Cecar123" },
            new UserModels { UserId = Guid.NewGuid(), Email = "Erik@gmail.com", FirstName = "Erik", LastName = "Eriksson", PhoneNumber = 0735097384, PasswordHash = "Erik123" },
            new UserModels { UserId = Guid.NewGuid(), Email = "Fredrik@gmail.com", FirstName = "Fredrik", LastName = "Fredriksson", PhoneNumber = 0735097384, PasswordHash = "Fredrik123" },
            new UserModels { UserId = Guid.NewGuid(), Email = "Gustav@gmail.com", FirstName = "Gustav", LastName = "Gustavsson", PhoneNumber = 0735097384, PasswordHash = "Gustav123" }
            };
            modelBuilder.Entity<UserModels>().HasData(Users);

            // Mock data for OrderModels
            var orders = new OrderModel[]
            {
                new OrderModel { OrderId = Guid.NewGuid(), UserId = users[0].UserId, OrderDate = DateTime.Now, TotalCost = 1000, OrderStatus = "Created" },
                new OrderModel { OrderId = Guid.NewGuid(), UserId = users[1].UserId, OrderDate = DateTime.Now, TotalCost = 2000, OrderStatus = "Created" },
                new OrderModel { OrderId = Guid.NewGuid(), UserId = users[2].UserId, OrderDate = DateTime.Now, TotalCost = 3000, OrderStatus = "Created" },
                new OrderModel { OrderId = Guid.NewGuid(), UserId = users[3].UserId, OrderDate = DateTime.Now, TotalCost = 4000, OrderStatus = "Created" },
            };
            modelBuilder.Entity<OrderModel>().HasData(orders);


            var warehouses = new WarehouseModel[]
            {
                new WarehouseModel { WarehouseId = Guid.NewGuid(), WarehouseName = "Warehouse 1"},
                new WarehouseModel { WarehouseId = Guid.NewGuid(), WarehouseName = "Warehouse 2"},
                new WarehouseModel { WarehouseId = Guid.NewGuid(), WarehouseName = "Warehouse 3"},
                new WarehouseModel { WarehouseId = Guid.NewGuid(), WarehouseName = "Warehouse 4"},
            };

            modelBuilder.Entity<WarehouseModel>().HasData(warehouses);

            var shelves = new ShelfModel[]
            {
                new ShelfModel { ShelfId = Guid.NewGuid(), ShelfRow = 1, ShelfColumn = 1, Occupancy = true ,WarehouseId = warehouses[0].WarehouseId},
                new ShelfModel { ShelfId = Guid.NewGuid(), ShelfRow = 2, ShelfColumn = 2, Occupancy = true ,WarehouseId = warehouses[1].WarehouseId},
                new ShelfModel { ShelfId = Guid.NewGuid(), ShelfRow = 3, ShelfColumn = 3, Occupancy = true ,WarehouseId = warehouses[2].WarehouseId},
                new ShelfModel { ShelfId = Guid.NewGuid(), ShelfRow = 4, ShelfColumn = 4, Occupancy = true ,WarehouseId = warehouses[3].WarehouseId},
            };

            modelBuilder.Entity<ShelfModel>().HasData(shelves);

            
            
            modelBuilder.Entity<UserModels>()
                .HasMany(u => u.Addresses)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId);



            base.OnModelCreating(modelBuilder);
        }
         
    }
}
