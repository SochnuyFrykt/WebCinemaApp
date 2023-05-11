using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Cinema_App.Models
{
    public class CinemaRoomModel
    {
        [System.ComponentModel.DataAnnotations.Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name_room")]
        public string? Name_Room { get; set; }

        [Column("id_cinema")]
        public int Id_Cinema { get; set; }
    }
}
