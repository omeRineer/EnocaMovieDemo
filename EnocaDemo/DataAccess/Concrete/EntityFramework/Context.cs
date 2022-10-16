using Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-0DGVKL8C;Database=EnocaMovieDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = Assembly.GetExecutingAssembly();
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Saloon> Saloons { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<MovieSaloon> MovieSaloons { get; set; }
    }
}
