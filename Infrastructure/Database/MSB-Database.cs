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
                new UserModels { UserId = Guid.NewGuid(), Email = "Adam@gmail.com", FirstName = "Adam", LastName = "Andersson", PasswordHash = "Adam123" },
                new UserModels { UserId = Guid.NewGuid(), Email = "Bertil@gmail.com", FirstName = "Bertil", LastName = "Bengtsson", PasswordHash = "Bertil123" },
                new UserModels { UserId = Guid.NewGuid(), Email = "Cecar@gmail.com", FirstName = "Cecar", LastName = "Citron", PasswordHash = "Cecar123" },
                new UserModels { UserId = Guid.NewGuid(), Email = "Erik@gmail.com", FirstName = "Erik", LastName = "Eriksson", PasswordHash = "Erik123" },
                new UserModels { UserId = Guid.NewGuid(), Email = "Fredrik@gmail.com", FirstName = "Fredrik", LastName = "Fredriksson", PasswordHash = "Fredrik123" },
                new UserModels { UserId = Guid.NewGuid(), Email = "Gustav@gmail.com", FirstName = "Gustav", LastName = "Gustavsson", PasswordHash = "Gustav123" }
                );

            modelBuilder.Entity<UserModels>()
                .HasMany(u => u.Addresses)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
