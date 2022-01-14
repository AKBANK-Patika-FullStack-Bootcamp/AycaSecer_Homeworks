using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Entities
{
    public class MovieContext : DbContext
    {

        protected readonly IConfiguration Configuration;

        public MovieContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //options.UseSqlServer(Configuration.GetConnectionString("MovieDBEntities"));
            options.UseSqlServer("Data Source=localhost; Database=MovieDB; integrated security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().ToTable("Movies");
            modelBuilder.Entity<MovieGenres>().ToTable("MovieGenres");
            modelBuilder.Entity<Logger>().ToTable("Logger");
        }
        public DbSet<Movie> movies { get; set; }
        public DbSet<MovieGenres> movieGenres { get; set; }
        public DbSet<Logger> logger { get; set; }
    }
}
