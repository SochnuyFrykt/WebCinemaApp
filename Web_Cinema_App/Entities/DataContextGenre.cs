using Microsoft.EntityFrameworkCore;
using Web_Cinema_App.Models;

namespace Web_Cinema_App.Entities
{
    public class DataContextGenre : DbContext
    {
        private string ConnectionPath =
           "Host=localhost;" +
           "Port=5432;" +
           "Username=postgres;" +
           "Password=root;" +
           "Database=Cinema_DB;";

        public DbSet<GenreModel> Genre { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectionPath);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GenreModel>(e => e.ToTable("genre"));
            base.OnModelCreating(modelBuilder);
        }
    }
}
