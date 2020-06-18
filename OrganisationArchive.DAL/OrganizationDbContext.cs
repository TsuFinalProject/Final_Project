using Microsoft.EntityFrameworkCore;
using OrganisationArchive.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganisationArchive.DAL
{
    public class OrganizationDbContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        public OrganizationDbContext(DbContextOptions options) : base(options)
        {           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Employee
            modelBuilder.Entity<Employee>().HasKey(x => x.Id);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Person)
                .WithMany(e => e.Employees)
                .HasForeignKey(f => f.PersonId);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Organization)
                .WithMany(e => e.Employees)
                .HasForeignKey(f => f.OrganizationId);

            modelBuilder.Entity<Employee>()
                .Property(x => x.Position)
                .IsRequired();

            //Person
            modelBuilder.Entity<Person>().HasKey(x => x.Id);
            modelBuilder.Entity<Person>()
                .Property(m => m.Name)
                .HasMaxLength(20)
                .IsRequired();

            modelBuilder.Entity<Person>()
                .Property(l => l.Lastname)
                .HasMaxLength(30)
                .IsRequired();

            modelBuilder.Entity<Person>()
               .Property(l => l.PersonalNumber)
               .HasMaxLength(11)
               .IsRequired();

            modelBuilder.Entity<Person>()
              .Property(l => l.PhoneNumber)
              .IsRequired();

            //Organization
            modelBuilder.Entity<Organization>().HasKey(x => x.Id);

            modelBuilder.Entity<Organization>()
                .Property(n => n.Name)
                .HasMaxLength(50);

            modelBuilder.Entity<Organization>()
                .Property(n => n.Address)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Organization>()
                .Property(n => n.Work)
                .IsRequired();
            //user 
            modelBuilder.Entity<User>()
                .Property(n => n.Username)
                .HasMaxLength(20);
        }
    }
}
