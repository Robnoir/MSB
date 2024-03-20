using Domain.Models.Address;
using Domain.Models.BoxModel;
using Domain.Models.OrderModel;
using Domain.Models.Shelf;
using Domain.Models.UserModel;
using Domain.Models.Warehouse;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
{
    public class MSB_Database : DbContext
    {

        public MSB_Database(DbContextOptions<MSB_Database> options) : base(options)
        {
        }

        public virtual DbSet<UserModel> Users { get; set; }
        public virtual DbSet<AddressModel> Addresses { get; set; }
        public virtual DbSet<OrderModel> Orders { get; set; }
        public virtual DbSet<WarehouseModel> Warehouses { get; set; }
        public virtual DbSet<ShelfModel> Shelves { get; set; }
        public virtual DbSet<BoxModel> Boxes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mock data for UserModels
            var users = new UserModel[]
            {
                new UserModel { Id = Guid.NewGuid(), Email = "Adam@gmail.com", FirstName = "Adam", LastName = "Andersson", Password = "Adam123" },
                new UserModel { Id = Guid.NewGuid(), Email = "Bertil@gmail.com", FirstName = "Bertil", LastName = "Bengtsson", Password = "Bertil123" },
                new UserModel { Id = Guid.NewGuid(), Email = "Cecar@gmail.com", FirstName = "Cecar", LastName = "Citron", Password = "Cecar123" },
                new UserModel { Id = Guid.NewGuid(), Email = "Erik@gmail.com", FirstName = "Erik", LastName = "Eriksson", Password = "Erik123" },
                new UserModel { Id = Guid.NewGuid(), Email = "Fredrik@gmail.com", FirstName = "Fredrik", LastName = "Fredriksson", Password = "Fredrik123" }
            };
            modelBuilder.Entity<UserModel>().HasData(users);

            // Mock data for OrderModels
            var orders = new OrderModel[]
            {
                new OrderModel { OrderId = Guid.NewGuid(), UserId = users[0].Id, OrderDate = DateTime.Now, TotalCost = 1000, OrderStatus = "Created", OrderNumber = 2101011000 },
                new OrderModel { OrderId = Guid.NewGuid(), UserId = users[1].Id, OrderDate = DateTime.Now, TotalCost = 2000, OrderStatus = "Created", OrderNumber = 2101011001 },
                new OrderModel { OrderId = Guid.NewGuid(), UserId = users[2].Id, OrderDate = DateTime.Now, TotalCost = 3000, OrderStatus = "Created"},
                new OrderModel { OrderId = Guid.NewGuid(), UserId = users[3].Id, OrderDate = DateTime.Now, TotalCost = 4000, OrderStatus = "Created"},
            };
            modelBuilder.Entity<OrderModel>().HasData(orders);

            // Mock data for BoxModel
            var boxes = new BoxModel[]
            {
                new BoxModel
                {
                    BoxId = Guid.NewGuid(),
                    Type = "Recycled",
                    TimesUsed = 2,
                    Stock = 20,
                    ImageUrl = "https://pngimg.com/uploads/spongebob/spongebob_PNG11.png",
                    UserNotes = "Bubbles",
                    OrderId = orders[0].OrderId,
                    Size = "M"
                },
                new BoxModel
                {
                    BoxId = Guid.NewGuid(),
                    Type = "Recycled",
                    TimesUsed = 0,
                    Stock = 10,
                    ImageUrl = "https://cdn.shopify.com/s/files/1/2393/5817/files/6eaedeb6-dd5a-4597-8976-247f08418c99.jpg?v=1692953727",
                    UserNotes = "Burgers",
                    OrderId = orders[1].OrderId,
                    Size = "XL"
                },
                new BoxModel
                {
                    BoxId = Guid.NewGuid(),
                    Type = "Recycled",
                    TimesUsed = 1,
                    Stock = 15,
                    ImageUrl = "https://cdn.shopify.com/s/files/1/2393/5817/files/SB_ES_Squid_002_EA_REV-S.jpg?v=1692953746",
                    UserNotes = "Money",
                    OrderId = orders[2].OrderId,
                    Size = "L"
                },
                new BoxModel
                {
                    BoxId = Guid.NewGuid(),
                    Type = "Recycled",
                    TimesUsed = 2,
                    Stock = 3,
                    ImageUrl = "https://cdn.shopify.com/s/files/1/2393/5817/files/renditionfile_6.jpg?v=1692953765",
                    UserNotes = "Chestnuts",
                    OrderId = orders[3].OrderId,
                    Size = "S"
                }
            };

            modelBuilder.Entity<BoxModel>().HasData(boxes);
            
            // Mock data for WarehouseModels
            var warehouses = new WarehouseModel[]
            {
                new WarehouseModel { WarehouseId = Guid.NewGuid(), WarehouseName = "Warehouse 1"},
                new WarehouseModel { WarehouseId = Guid.NewGuid(), WarehouseName = "Warehouse 2"},
                new WarehouseModel { WarehouseId = Guid.NewGuid(), WarehouseName = "Warehouse 3"},
                new WarehouseModel { WarehouseId = Guid.NewGuid(), WarehouseName = "Warehouse 4"},
            };
            modelBuilder.Entity<WarehouseModel>().HasData(warehouses);

            // Mock data for ShelfModels
            var shelves = new ShelfModel[]
            {
                new ShelfModel { ShelfId = Guid.NewGuid(), ShelfRow = 1, ShelfColumn = 1, Occupancy = true ,WarehouseId = warehouses[0].WarehouseId},
                new ShelfModel { ShelfId = Guid.NewGuid(), ShelfRow = 2, ShelfColumn = 2, Occupancy = true ,WarehouseId = warehouses[1].WarehouseId},
                new ShelfModel { ShelfId = Guid.NewGuid(), ShelfRow = 3, ShelfColumn = 3, Occupancy = true ,WarehouseId = warehouses[2].WarehouseId},
                new ShelfModel { ShelfId = Guid.NewGuid(), ShelfRow = 4, ShelfColumn = 4, Occupancy = true ,WarehouseId = warehouses[3].WarehouseId},
            };
            modelBuilder.Entity<ShelfModel>().HasData(shelves);

            // Create database schema
            base.OnModelCreating(modelBuilder);
        }
    }
}
