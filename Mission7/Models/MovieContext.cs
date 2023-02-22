using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext (DbContextOptions<MovieContext> options) : base(options)
        {

        }

        public DbSet<MovieSubmission> Submissions { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            //Categories 
            mb.Entity<Category>().HasData(
               new Category { CategoryId = 1, CategoryName = "Action/Adventure" },
               new Category { CategoryId = 2, CategoryName = "Drama" },
               new Category { CategoryId = 3, CategoryName = "Comedy" },
               new Category { CategoryId = 4, CategoryName = "Family" },
               new Category { CategoryId = 5, CategoryName = "Horror/Suspense" },
               new Category { CategoryId = 6, CategoryName = "Miscellaneous" },
               new Category { CategoryId = 7, CategoryName = "Television" },
               new Category { CategoryId = 8, CategoryName = "VHS" }
               );
            //Data seed
            mb.Entity<MovieSubmission>().HasData(
            new MovieSubmission
            {
                MovieId = 2,
                CategoryID = 1,
                Title = "Spider-Man",
                Year = 2002,
                Director = "Sam Raimi",
                Rating = "PG-13"
            },

            new MovieSubmission
            {
                MovieId = 3,
                CategoryID = 2,
                Title = "Invincible",
                Year = 2006,
                Director = "M. Night Shyamalan",
                Rating = "PG"
            },

            new MovieSubmission
            {
                MovieId = 4,
                CategoryID = 3,
                Title = "spirited ",
                Year = 2022,
                Director = "Sean Anders",
                Rating = "PG-13"
            }
          );
        }
    }
}

