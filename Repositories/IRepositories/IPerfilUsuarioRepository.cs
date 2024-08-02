using TicketSystem.Models;

namespace TicketSystem.Repositories.IRepositories
{
    public interface IPerfilUsuarioRepository
    {
        Task<IEnumerable<PerfilUsuario>> GetAllPerfilesUsuarioAsync();
        Task<PerfilUsuario> GetPerfilUsuarioByIdAsync(int id);
        Task AddPerfilUsuarioAsync(PerfilUsuario perfilUsuario);
        Task UpdatePerfilUsuarioAsync(PerfilUsuario perfilUsuario);
        Task DeletePerfilUsuarioAsync(int id);
    }
}
