using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketSystem.Models
{
    public class Equipo
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(255)]
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaEliminacion { get; set; }
        public DateTime? FechaUltimaActualizacion { get; set; }
        public int EstadoId { get; set; }
        public bool Activo { get; set; }

        [ForeignKey("EstadoId")]
        public virtual Catalogo Estado { get; set; }
    }

}
