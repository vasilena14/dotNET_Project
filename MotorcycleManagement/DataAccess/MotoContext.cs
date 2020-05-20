using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructure;

namespace DataAccess
{
    public partial class MotoContext : DbContext
    {
        public MotoContext() : base("name=MotoContext")
        {
        }

        public virtual DbSet<Motorcycle> Motorcycles { get; set; }

        public virtual DbSet<Brand> Brands { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Engine> Engines { get; set; }


        /*public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }

        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }

        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }

        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<AspNetRoles>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);
        }*/
    }
}
