using Domain.Models.Address;
using Domain.Models.UserModel;
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

        public MSB_Database(DbContextOptions<MSB_Database> options) : base(options) { }


        public virtual DbSet<UserModels> Users { get; set; }
        public virtual DbSet<AddressModel> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModels>().HasData(
                new UserModels { UserId = Guid.NewGuid(), Email = "Adam@gmail.com", FirstName = "Adam", LastName = "Andersson", PhoneNumber = 0735097384, PasswordHash = "Adam123" },
                new UserModels { UserId = Guid.NewGuid(), Email = "Bertil@gmail.com", FirstName = "Bertil", LastName = "Bengtsson", PhoneNumber = 0735097384, PasswordHash = "Bertil123" },
                new UserModels { UserId = Guid.NewGuid(), Email = "Cecar@gmail.com", FirstName = "Cecar", LastName = "Citron", PhoneNumber = 0735097384, PasswordHash = "Cecar123" },
                new UserModels { UserId = Guid.NewGuid(), Email = "Erik@gmail.com", FirstName = "Erik", LastName = "Eriksson", PhoneNumber = 0735097384, PasswordHash = "Erik123" },
                new UserModels { UserId = Guid.NewGuid(), Email = "Fredrik@gmail.com", FirstName = "Fredrik", LastName = "Fredriksson", PhoneNumber = 0735097384, PasswordHash = "Fredrik123" },
                new UserModels { UserId = Guid.NewGuid(), Email = "Gustav@gmail.com", FirstName = "Gustav", LastName = "Gustavsson", PhoneNumber = 0735097384, PasswordHash = "Gustav123" }
                );

            modelBuilder.Entity<UserModels>()
                .HasMany(u => u.Addresses)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
