using TicketSystem.Models;

namespace TicketSystem.Repositories.IRepositories
{
    public interface IPermisoRepository
    {
        Task<IEnumerable<Permiso>> GetAllPermisosAsync();
        Task<Permiso> GetPermisoByIdAsync(int perfilId, int usuarioId);
        Task AddPermisoAsync(Permiso permiso);
        Task UpdatePermisoAsync(Permiso permiso);
        Task DeletePermisoAsync(int perfilId, int usuarioId);
    }
}
