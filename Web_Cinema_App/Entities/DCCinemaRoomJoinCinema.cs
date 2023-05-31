using Microsoft.EntityFrameworkCore;
using Web_Cinema_App.Models;

namespace Web_Cinema_App.Entities
{
    public class DCCinemaRoomJoinCinema : DbContext
    {
        private string ConnectionPath =
           "Host=localhost;" +
           "Port=5432;" +
           "Username=postgres;" +
           "Password=root;" +
           "Database=Cinema_DB;";

        public DbSet<CinemaModel> Cinema { get; set; }
        public DbSet<CinemaRoomModel> CinemaRoom { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectionPath);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
