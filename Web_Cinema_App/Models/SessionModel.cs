using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Cinema_App.Models
{
    public class SessionModel
    {
        [System.ComponentModel.DataAnnotations.Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("date", TypeName = "date")]
        public DateOnly Date { get; set; }

        [Column("time", TypeName = "time without time zone")]
        public TimeOnly Time { get; set; }

        [Column("id_film")]
        public int IdFilm { get; set; }
    }
}
