using Domain.Models.Address;
using Domain.Models.OrderModel;
using Domain.Models.UserModel;
using Domain.Models.Warehouse;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Reflection.Emit;

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
                new OrderModel { OrderId = Guid.NewGuid(), UserId = users[0].Id, OrderDate = DateTime.Now, TotalCost = 1000, OrderStatus = "Created" },
                new OrderModel { OrderId = Guid.NewGuid(), UserId = users[1].Id, OrderDate = DateTime.Now, TotalCost = 2000, OrderStatus = "Created" },
                new OrderModel { OrderId = Guid.NewGuid(), UserId = users[2].Id, OrderDate = DateTime.Now, TotalCost = 3000, OrderStatus = "Created" },
                new OrderModel { OrderId = Guid.NewGuid(), UserId = users[3].Id, OrderDate = DateTime.Now, TotalCost = 4000, OrderStatus = "Created" },
            };

            modelBuilder.Entity<OrderModel>().HasData(orders);

            // Mock data for AddressModels
            var addresses = new AddressModel[]
            {
                  new AddressModel {AddressId = Guid.NewGuid(), StreetName = "Maple Street", Apartment = "Apt 3B", ZipCode = "12345", Floor = "2nd", City = "Springfield", State = "Ohio", Country = "USA", Latitude = "39.9266", Longitude = "-83.8064", },
                  new AddressModel {AddressId = Guid.NewGuid(), StreetName = "Oak Avenue", Apartment = "Apt 2A", ZipCode = "54321", Floor = "Ground Floor", City = "Willow Creek", State = "California", Country = "USA", Latitude = "37.7833", Longitude = "-122.4167", },
                  new AddressModel {AddressId = Guid.NewGuid(), StreetName = "Elm Street", Apartment = "Apt 5C", ZipCode = "98765", Floor = "3rd", City = "Oakville", State = "New York", Country = "USA", Latitude = "40.7128", Longitude = "-74.0060", },
                  new AddressModel {AddressId = Guid.NewGuid(), StreetName = "Pine Street", Apartment = "Apt 10D", ZipCode = "67890", Floor = "4th", City = "Cedarville", State = "Texas", Country = "USA", Latitude = "31.9686", Longitude = "-99.9018", },
            };

            modelBuilder.Entity<AddressModel>().HasData(addresses);

            base.OnModelCreating(modelBuilder);
        }



    }
}
