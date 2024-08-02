using Microsoft.EntityFrameworkCore;
using TicketSystem.Models;

namespace TicketSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Permiso> Permisos { get; set; }
        public DbSet<Catalogo> Catalogos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<CombinacionDeColores> CombinacionDeColores { get; set; }
        public DbSet<PerfilUsuario> PerfilUsuarios { get; set; }
    }
}
