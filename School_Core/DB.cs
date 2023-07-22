using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using School_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Core
{
    public class DB : DbContext
    {
        public DB(DbContextOptions<DB> options) : base(options)
        {

        }

        public DbSet<Class> Classes { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<ClassesStudent> ClassesStudents { get; set; }

        public DbSet<UserTitle> UserTitle { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>().HasMany(n => n.Students).WithMany(n => n.Classes).UsingEntity<ClassesStudent>();
            modelBuilder.Entity<ClassesStudent>().HasKey(n => n.Id);
            modelBuilder.Entity<ClassesStudent>().HasIndex(n => new { n.StudentId, n.ClassId }).IsUnique(true);
            modelBuilder.Entity<Class>().HasIndex(n=>n.Name).IsUnique(true);
            modelBuilder.Entity<Student>().HasIndex(n=>n.NationalCode).IsUnique(true);
            modelBuilder.Entity<Teacher>().HasIndex(n => n.NationalCode).IsUnique(true);
        }
    }
}


