using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketSystem.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(255)]
        public string Titulo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaCierre { get; set; }
        public DateTime? FechaUltimaActualizacion { get; set; }
        public string TiempoEstimadoResolucion { get; set; } // Formato dd:hh:mm
        [Required, StringLength(255)]
        public string NombreCreador { get; set; }
        public int EquipoResponsableId { get; set; }
        public int ResponsableSolucionId { get; set; }

        [ForeignKey("TipoIncidenciaId")]
        public int TipoIncidenciaId { get; set; }
        [ForeignKey("GravedadIncidenciaId")]
        public int GravedadIncidenciaId { get; set; }

        [StringLength(255)]
        public string VersionSoftware { get; set; }
        [Required, StringLength(4000)]
        public string DescripcionCompleta { get; set; }
        public int EstadoId { get; set; }
        public bool Activo { get; set; }
        public int? ModuloId { get; set; }
        [StringLength(1000)]
        public string ArchivosRelacionados { get; set; } // JSON links

        [ForeignKey("EquipoResponsableId")]
        public virtual Equipo EquipoResponsable { get; set; }
        [ForeignKey("ResponsableSolucionId")]
        public virtual Usuario ResponsableSolucion { get; set; }
    }
}
