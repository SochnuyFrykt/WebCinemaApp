using Microsoft.EntityFrameworkCore;
using Web_Cinema_App.Models;

namespace Web_Cinema_App.Entities
{
    public class DataContextTicket : DbContext
    {
        private string ConnectionPath =
           "Host=localhost;" +
           "Port=5432;" +
           "Username=postgres;" +
           "Password=root;" +
           "Database=Cinema_DB;";

        public DbSet<TicketModel> Ticket { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectionPath);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TicketModel>(e => e.ToTable("ticket"));
            base.OnModelCreating(modelBuilder);
        }
    }
}
