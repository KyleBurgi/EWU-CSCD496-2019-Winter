using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecretSanta.Domain.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Gift> Gifts { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<UserGroup> UserGroup { get; set; }
        public DbSet<Pairing> Pairing { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserGroup>().HasKey(userGroup => new { userGroup.UserId, userGroup.GroupId });

            modelBuilder.Entity<UserGroup>().HasOne(userGroup => userGroup.User).WithMany(user => user.UserGroup).HasForeignKey(userGroup => userGroup.UserId);

            modelBuilder.Entity<UserGroup>().HasOne(userGroup => userGroup.Group).WithMany(group => group.UserGroup).HasForeignKey(userGroup => userGroup.GroupId);
        }
    }
}
