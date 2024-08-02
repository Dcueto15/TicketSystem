using System.Collections.Generic;
using System.Threading.Tasks;
using TicketSystem.Models;

namespace TicketSystem.Services
{
    public interface IPermisoService
    {
        Task<IEnumerable<Permiso>> GetAllPermisosAsync();
        Task<Permiso> GetPermisoByIdAsync(int perfilId, int usuarioId);
        Task AddPermisoAsync(Permiso permiso);
        Task UpdatePermisoAsync(Permiso permiso);
        Task DeletePermisoAsync(int perfilId, int usuarioId);
    }
}
