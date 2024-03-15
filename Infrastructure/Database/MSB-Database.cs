using Domain.Models.Address;
using Domain.Models.UserModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database
{
    public class MSB_Database : DbContext
    {
        public MSB_Database() { }
        public MSB_Database(DbContextOptions<MSB_Database> options) : base(options) { }


        public virtual DbSet<UserModel> Users { get; set; }
        public virtual DbSet<AddressModel> Addresses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().HasData(
                new UserModel { Id = Guid.NewGuid(), Email = "Adam@gmail.com", FirstName = "Adam", LastName = "Andersson", Password = "Adam123" },
                new UserModel { Id = Guid.NewGuid(), Email = "Bertil@gmail.com", FirstName = "Bertil", LastName = "Bengtsson", Password = "Bertil123" }
                );



            base.OnModelCreating(modelBuilder);
        }



    }
}
