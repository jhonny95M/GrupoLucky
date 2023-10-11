using Lucky.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Lucky.Repositories.EFCore
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(c => c.Id).HasMaxLength(5);
            modelBuilder.Entity<User>().Property(c => c.Email).IsRequired().HasMaxLength(40);
            modelBuilder.Entity<User>().Property(c => c.UserName).HasMaxLength(40).IsRequired();
            modelBuilder.Entity<User>().Property(c => c.PasswordHash).HasMaxLength(40).IsRequired();
            modelBuilder.Entity<User>().HasData(new User { Id = 1,Email="juniorjhonnymalpartida@gmail.com",UserName="JMalpartida",PasswordHash="1234" });
        }
    }

}