using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;

namespace Mission6_shaw.Models
{
    public class MovieRatingContext : DbContext
    {

        public MovieRatingContext(DbContextOptions<MovieRatingContext> options) : base(options)
        {
        }

        public DbSet<MovieRating> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
//context file for the database setup