using Microsoft.EntityFrameworkCore;
using MyLibrary.DataAccess.Configurations;
using MyLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary.DataAccess
{
    public class MyLibraryDbContext :DbContext
    {
        //public MyLibraryDbContext(DbContextOptions<MyLibraryDbContext> options):base(options)
        //{

        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-MD8KOD4;Database=MyLibraryDb; uid=sa;pwd=11235813");
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());

        }

    }
}










//base.OnModelCreating(modelBuilder);

//modelBuilder.ApplyConfiguration(new CategoryConfiguration());
//modelBuilder.ApplyConfiguration(new BookConfiguration());