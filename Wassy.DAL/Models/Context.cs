using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Wassy.DAL.Models;

namespace Wassy.DAL.Models
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categoriess { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Relative> Relatives { get; set; }
        public DbSet<Responsible> Responsibles { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<Relation> Relations { get; set; }
        public DbSet<LogIn> LogIns { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{

        //    // Configure Relative & Contact entity
        //    modelBuilder.Entity<Relative>()
        //                .HasOptional(r => r.Contact) // Mark Address property optional in Student entity
        //                .WithRequired(c => c.Relative); // mark Student property as required in StudentAddress entity. Cannot save StudentAddress without Student


        //modelBuilder.Entity<Property>()
        //        .HasOptional<User>(s => s.User)
        //        .WithMany(s => s.Properties)
        //        .HasForeignKey(s => s.UserId);

        //modelBuilder.Entity<Relative>()
        //       .HasOptional<User>(s => s.User)
        //       .WithMany(s => s.Relatives)
        //       .HasForeignKey(s => s.UserId);

        //modelBuilder.Entity<Responsible>()
        //      .HasOptional<User>(s => s.User)
        //      .WithMany(s => s.Responsible)
        //      .HasForeignKey(s => s.UserId);
    }






}
