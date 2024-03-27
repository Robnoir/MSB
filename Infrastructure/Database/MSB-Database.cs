using Domain.Models.Address;
using Domain.Models.BoxModel;
using Domain.Models.Car;
using Domain.Models.Driver;
using Domain.Models.Employee;
using Domain.Models.Order;
using Domain.Models.Shelf;
using Domain.Models.User;
using Domain.Models.Warehouse;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
{
    public class MSB_Database : DbContext
    {
        public MSB_Database(DbContextOptions<MSB_Database> options) : base(options) { }

        public virtual DbSet<UserModel> Users { get; set; }
        public virtual DbSet<EmployeeModel> Employees { get; set; }
        public virtual DbSet<AddressModel> Addresses { get; set; }
        public virtual DbSet<DriverModel> Drivers { get; set; }
        public virtual DbSet<CarModel> Cars { get; set; }
        public virtual DbSet<OrderModel> Orders { get; set; }
        public virtual DbSet<WarehouseModel> Warehouses { get; set; }
        public virtual DbSet<ShelfModel> Shelves { get; set; }
        public virtual DbSet<BoxModel> Boxes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mock data for UserModels
            var users = new UserModel[]
            {
            new UserModel{ UserId = Guid.NewGuid(), Email = "Adam@gmail.com", FirstName = "Adam", LastName = "Andersson", PhoneNumber = "0735097384", PasswordHash = "Adam123",  },
            new UserModel { UserId = Guid.NewGuid(), Email = "Bertil@gmail.com", FirstName = "Bertil", LastName = "Bengtsson", PhoneNumber = "0735097384", PasswordHash = "Bertil123" },
            new UserModel { UserId = Guid.NewGuid(), Email = "Cecar@gmail.com", FirstName = "Cecar", LastName = "Citron", PhoneNumber = "0735097384", PasswordHash = "Cecar123" },
            new UserModel { UserId = Guid.NewGuid(), Email = "Erik@gmail.com", FirstName = "Erik", LastName = "Eriksson", PhoneNumber = "0735097384", PasswordHash = "Erik123" },
            };


            // Mock data for AddressModels
            var addresses = new AddressModel[]
            {
                new AddressModel { AddressId = Guid.NewGuid(), StreetName = "Maple Street", StreetNumber ="21" , Apartment = "Apt 3B", ZipCode = "12345", Floor = "2nd", City = "Springfield", State = "Ohio", Country = "USA", Latitude = "39.9266", Longitude = "-83.8064" },
                new AddressModel { AddressId = Guid.NewGuid(), StreetName = "Oak Avenue", StreetNumber ="22" ,Apartment = "Apt 2A", ZipCode = "54321", Floor = "Ground Floor", City = "Willow Creek", State = "California", Country = "USA", Latitude = "37.7833", Longitude = "-122.4167" },
                new AddressModel { AddressId = Guid.NewGuid(), StreetName = "Elm Street", StreetNumber ="23" , Apartment = "Apt 5C", ZipCode = "98765", Floor = "3rd", City = "Oakville", State = "New York", Country = "USA", Latitude = "40.7128", Longitude = "-74.0060" },
                new AddressModel { AddressId = Guid.NewGuid(), StreetName = "Pine Street", StreetNumber ="24", Apartment = "Apt 10D", ZipCode = "67890", Floor = "4th", City = "Cedarville", State = "Texas", Country = "USA", Latitude = "31.9686", Longitude = "-99.9018" }
            };

            //for (int i = 0; i < users.Length; i++)
            //{
            //    users[i].Addresses = addresses[i].AddressId;
            //}
            modelBuilder.Entity<UserModel>().HasData(users);
            for (int i = 0; i < users.Length; i++)
            {
                addresses[i].UserId = users[i].UserId;
            }
            modelBuilder.Entity<AddressModel>().HasData(addresses);

            modelBuilder.Entity<UserModel>()
                .HasMany(u => u.Addresses)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Mock data for OrderModels
            var orders = new OrderModel[]
            {
                new OrderModel { OrderId = Guid.NewGuid(), UserId = users[0].UserId, OrderDate = DateTime.Now, TotalCost = 1000, OrderStatus = "Created", OrderNumber = 2101011000},
                new OrderModel { OrderId = Guid.NewGuid(), UserId = users[1].UserId, OrderDate = DateTime.Now, TotalCost = 2000, OrderStatus = "Created", OrderNumber = 2101011001},
                new OrderModel { OrderId = Guid.NewGuid(), UserId = users[2].UserId, OrderDate = DateTime.Now, TotalCost = 3000, OrderStatus = "Created", OrderNumber = 2101011100},
                new OrderModel { OrderId = Guid.NewGuid(), UserId = users[3].UserId, OrderDate = DateTime.Now, TotalCost = 4000, OrderStatus = "Created", OrderNumber = 2101010101},
            };
            modelBuilder.Entity<OrderModel>().HasData(orders);

            //Mock data for BoxModel
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

            base.OnModelCreating(modelBuilder);
        }
    }
}