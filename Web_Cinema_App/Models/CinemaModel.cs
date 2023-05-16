using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Cinema_App.Models
{
    public class CinemaModel
    {
        [System.ComponentModel.DataAnnotations.Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name_cinema")]
        public string? NameCinema { get; set; }
    }
}
