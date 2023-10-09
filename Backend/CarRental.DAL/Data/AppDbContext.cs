using CarRental.Shared.DTO_s;
using CarRental.Shared.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<Car> car { get; set; }
        public DbSet<User> user { get; set; }
        public DbSet<RentalAgreement> rentalagreement { get; set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = new Guid("ebb7824169904ee98c2b968bd3e400c3"),
                Name = "Tester",
                Email = "Tester@test.com",
                Password = "Markmark",
                PhoneNo = "7982215948",
                IsAdmin = true,
            });
            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = new Guid("2d8382a41c8745e786e1b2fcfa0741aa"),
                Name = "Purusharth",
                Email = "purutyagi18@gmail.com",
                Password = "Tyagityagi",
                PhoneNo = "8287530685",
                IsAdmin = false,
            });
            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = new Guid("fac2a973aaea4108a31d1cad2f662fad"),
                Name = "Puru",
                Email = "purusharthtyagi22@gmail.com",
                Password = "Tyagityagi1818",
                PhoneNo = "8287530685",
                IsAdmin = false,
            });
        }
    }
}
