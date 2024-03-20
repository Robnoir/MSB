using Domain.Models.Address;
using Domain.Models.BoxModel;
using Domain.Models.UserModel;
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
        public virtual DbSet<BoxModel> Boxes { get; set; }

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
