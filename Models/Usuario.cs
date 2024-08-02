using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketSystem.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(255)]
        public string NombreCompleto { get; set; }
        public int PerfilUsuarioId { get; set; }
        public int? EquipoId { get; set; }
        [Required, StringLength(255)]
        public string Key { get; set; }

        [ForeignKey("PerfilUsuarioId")]
        public virtual PerfilUsuario PerfilUsuario { get; set; }
        [ForeignKey("EquipoId")]
        public virtual Equipo Equipo { get; set; }
    }

}
