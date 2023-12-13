using Doordash.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Doordash.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Resturant> Resturants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AddressesModelCreate(modelBuilder);
            ResturantsModelCreate(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void ResturantsModelCreate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resturant>()
               .HasKey(e => e.Id);

            modelBuilder.Entity<Resturant>()
                .Property(e => e.CreatedOn)
                .IsRequired();

            modelBuilder.Entity<Resturant>()
                .Property(e => e.Description)
                .IsRequired();

            modelBuilder.Entity<Resturant>()
                .Property(e => e.Name)
                .IsRequired();

            modelBuilder.Entity<Resturant>()
                .Property(e => e.Type)
                .IsRequired();

            modelBuilder.Entity<Resturant>()
                .HasOne(r => r.Address)
                .WithOne(a => a.Resturant)
                .HasForeignKey<Address>(r => r.ResturantId);
        }

        private void AddressesModelCreate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Address>()
                .Property(e => e.Town)
                .IsRequired();

            modelBuilder.Entity<Address>()
                .Property(e => e.Type)
                .IsRequired();

            modelBuilder.Entity<Address>()
                .Property(e => e.AreaCode)
                .IsRequired();

            modelBuilder.Entity<Address>()
                .Property(e => e.StreetAddress)
                .IsRequired();

            modelBuilder.Entity<Address>()
                .Property(e => e.HouseNumber)
                .IsRequired();
        }
    }
}
