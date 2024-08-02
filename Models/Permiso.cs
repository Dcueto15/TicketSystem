using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketSystem.Models
{
    public class Permiso
    {
        [Key, Column(Order = 0)]
        public int PerfilId { get; set; }
        [Key, Column(Order = 1)]
        public int UsuarioId { get; set; }
        [Required, StringLength(255)]
        public string Seccion { get; set; }
        public bool Crear { get; set; }
        public bool Actualizar { get; set; }
        public bool Eliminar { get; set; }
        public bool Ver { get; set; }

        [ForeignKey("PerfilId")]
        public virtual PerfilUsuario Perfil { get; set; }
        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; }
    }

}
