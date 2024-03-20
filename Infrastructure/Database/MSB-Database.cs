using Domain.Models.Address;
using Domain.Models.Driver;
using Domain.Models.Employee;
using Domain.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database
{
    public class MSB_Database : DbContext
    {

        public MSB_Database(DbContextOptions<MSB_Database> options) : base(options)
        {
        }


        public virtual DbSet<UserModel> Users { get; set; }
        public virtual DbSet<EmployeeModel> Employees { get; set; }
        public virtual DbSet<AddressModel> Addresses { get; set; }
        public virtual DbSet<DriverModel> Drivers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().HasData(
                new UserModel { Id = Guid.NewGuid(), Email = "Adam@gmail.com", FirstName = "Adam", LastName = "Andersson", Password = "Adam123" },
                new UserModel { Id = Guid.NewGuid(), Email = "Bertil@gmail.com", FirstName = "Bertil", LastName = "Bengtsson", Password = "Bertil123" },
                new UserModel { Id = Guid.NewGuid(), Email = "Cecar@gmail.com", FirstName = "Cecar", LastName = "Citron", Password = "Cecar123" },
                new UserModel { Id = Guid.NewGuid(), Email = "Erik@gmail.com", FirstName = "Erik", LastName = "Eriksson", Password = "Erik123" },
                new UserModel { Id = Guid.NewGuid(), Email = "Fredrik@gmail.com", FirstName = "Fredrik", LastName = "Fredriksson", Password = "Fredrik123" }
                );



            base.OnModelCreating(modelBuilder);
        }



    }
}
