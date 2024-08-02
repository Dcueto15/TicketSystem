using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketSystem.Models
{
    public class PerfilUsuario
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(255)]
        public string Nombre { get; set; }
    }

}
