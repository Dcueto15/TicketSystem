using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketSystem.Models
{
    public class Tarea
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(255)]
        public string Titulo { get; set; }
        [StringLength(1000)]
        public string Descripcion { get; set; }
        public int Posicion { get; set; }
        [ForeignKey("EstadoId")]
        public int EstadoId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaFinalizacion { get; set; }
        public DateTime? FechaUltimaActualizacion { get; set; }
        public bool Activo { get; set; }
        [ForeignKey("ResponsableId")]
        public int ResponsableId { get; set; }
        public virtual Catalogo Estado { get; set; }
        public virtual Usuario Responsable { get; set; }
    }

}
