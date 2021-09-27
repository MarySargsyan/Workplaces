using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Workplaces.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Items> Items { get; set; }
        public DbSet<Workplace> Workplaces { get; set; }  
        public DbSet<User> Users { get; set; }  
        public DbSet<Role> Roles { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<PlaceItem> PlaceItems { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
            Database.EnsureCreated();
        }
        public AppDbContext() : base() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlaceItem>().HasKey(pi => new { pi.ItemId, pi.WorkplaceId });
            modelBuilder.Entity<PlaceItem>().
                HasOne(pi => pi.items).WithMany(pi => pi.placeItem).HasForeignKey(p => p.ItemId);
            modelBuilder.Entity<PlaceItem>().
                HasOne(pi => pi.workplace).WithMany(pi => pi.placeItem).HasForeignKey(p => p.WorkplaceId);

            string adminRoleName = "admin";
            string userRoleName = "user";
 
            string adminEmail = "admin@mail.ru";
            string adminPassword = "123456";
            string adminName = "Mary";
            string adminSourName = "Sargsyan";
 
            // добавляем роли
            Role adminRole = new Role { Id = 1, Name = adminRoleName };
            Role userRole = new Role { Id = 2, Name = userRoleName };
            User adminUser = new User { Id = 1, Name= adminName, SourName= adminSourName, Email = adminEmail, Password = adminPassword, RoleId = adminRole.Id };
 
            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
            modelBuilder.Entity<User>().HasData( new User[] { adminUser });
            base.OnModelCreating(modelBuilder);
        }
    }
}
