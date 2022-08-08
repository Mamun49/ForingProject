using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ForingProject.Models
{
    public partial class ForingModel : DbContext
    {
        public ForingModel()
            : base("name=ForingModel")
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<tblImage> tblImages { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(e => e.ProductName)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductPrice)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductType)
                .IsUnicode(false);

            modelBuilder.Entity<tblImage>()
                .Property(e => e.ImagePath)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.Mail)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.Gender)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.ConfirmPassword)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.RoleName)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.MemberStatus)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.UserRoles)
                .WithRequired(e => e.user)
                .WillCascadeOnDelete(false);

            //modelBuilder.Entity<UserRole>()
            //    .Property(e => e.UserRole1)
            //    .IsUnicode(false);

            modelBuilder.Entity<UserRole>()
                .Property(e => e.Role)
                .IsUnicode(false);

        }
    }
}
