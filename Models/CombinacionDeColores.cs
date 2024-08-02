using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketSystem.Models
{
    public class CombinacionDeColores
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(255)]
        public string Nombre { get; set; }
        [Required, StringLength(255)]
        public string ColorTexto { get; set; }
        [Required, StringLength(255)]
        public string ColorFondo { get; set; }
        public bool Activo { get; set; }
    }

}
