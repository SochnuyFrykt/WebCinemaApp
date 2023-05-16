using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Cinema_App.Models
{
    public class TicketModel
    {
        [System.ComponentModel.DataAnnotations.Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("id_session")]
        public int IdSession { get; set; }

        [Column("id_place")]
        public int IdPlace { get; set; }

        [Column("status")]
        public bool Status { get; set; }

        [Column("price")]
        public int Price { get; set; }
    }
}
