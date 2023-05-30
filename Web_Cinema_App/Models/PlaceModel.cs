using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Cinema_App.Models
{
    public class PlaceModel
    {
        [System.ComponentModel.DataAnnotations.Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("id_room")]
        public int IdRoom { get; set; }

        [Column("number")]
        public int Number { get; set; }

        [Column("row")]
        public int Row { get; set; }
    }
}
