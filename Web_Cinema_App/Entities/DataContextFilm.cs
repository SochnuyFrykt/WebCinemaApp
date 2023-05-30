using Microsoft.EntityFrameworkCore;
using Web_Cinema_App.Models;

namespace Web_Cinema_App.Entities
{
    public class DataContextFilm : DbContext
    {
        private string ConnectionPath =
           "Host=localhost;" +
           "Port=5432;" +
           "Username=postgres;" +
           "Password=root;" +
           "Database=Cinema_DB;";

        public DbSet<FilmModel> Film { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectionPath);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FilmModel>(e => e.ToTable("film"));
            base.OnModelCreating(modelBuilder);
        }
    }
}
