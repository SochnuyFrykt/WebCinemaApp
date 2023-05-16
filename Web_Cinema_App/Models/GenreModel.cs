using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Cinema_App.Models
{
    public class GenreModel
    {
        [System.ComponentModel.DataAnnotations.Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("genre")]
        public string Genre { get; set; }
    }
}
