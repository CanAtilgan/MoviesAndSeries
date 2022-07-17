using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //veri tabanı(db tabloları) ile entity classlarını ilişkilendirme 
    //CONTEXT NESNESİ
    public class MovieAndSeriesContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-VUF97SF;Initial Catalog=NetfilixClone;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Movie> Movies { get; set; }
        
        public DbSet<Series> Series { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MovieImage> MovieImages { get; set; }
    }
}


    