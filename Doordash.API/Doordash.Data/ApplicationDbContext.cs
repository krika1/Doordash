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

        public DbSet<MenuItem> MenuItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AddressesModelCreate(modelBuilder);
            MenuItemsModelCreate(modelBuilder);
            ResturantsModelCreate(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void MenuItemsModelCreate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuItem>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<MenuItem>()
                .Property(m => m.Name)
                .IsRequired();

            modelBuilder.Entity<MenuItem>()
                .Property(m => m.Description)
                .IsRequired();

            modelBuilder.Entity<MenuItem>()
                .Property(m => m.Price)
                .IsRequired();
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

            modelBuilder.Entity<Resturant>()
                .HasMany(r => r.MenuItems)
                .WithOne(m => m.Resturant)
                .HasForeignKey(m => m.ResturantId);
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
