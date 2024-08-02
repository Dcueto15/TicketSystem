using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketSystem.Models
{
    public class Catalogo
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(255)]
        public string Categoria { get; set; }
        [Required, StringLength(255)]
        public string Texto { get; set; }
        public int CombinacionColoresId { get; set; }

        [ForeignKey("CombinacionColoresId")]
        public virtual CombinacionDeColores CombinacionColores { get; set; }
    }

}
