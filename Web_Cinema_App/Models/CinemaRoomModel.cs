using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Cinema_App.Models
{
    public class CinemaRoomModel
    {
        [System.ComponentModel.DataAnnotations.Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name_room")]
        public string NameRoom { get; set; }

        [Column("id_cinema")]
        public int IdCinema { get; set; }
    }
}
