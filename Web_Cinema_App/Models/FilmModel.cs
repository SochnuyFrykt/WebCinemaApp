using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Cinema_App.Models
{
    public class FilmModel
    {
        [System.ComponentModel.DataAnnotations.Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name_film")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("id_genre")]
        public int IdGenre { get; set; }
    }
}
