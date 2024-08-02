using System.Collections.Generic;
using System.Threading.Tasks;
using TicketSystem.Models;

namespace TicketSystem.Services
{
    public interface IPerfilUsuarioService
    {
        Task<IEnumerable<PerfilUsuario>> GetAllPerfilesUsuarioAsync();
        Task<PerfilUsuario> GetPerfilUsuarioByIdAsync(int id);
        Task AddPerfilUsuarioAsync(PerfilUsuario perfilUsuario);
        Task UpdatePerfilUsuarioAsync(PerfilUsuario perfilUsuario);
        Task DeletePerfilUsuarioAsync(int id);
    }
}
