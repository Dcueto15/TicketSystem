using System.Collections.Generic;
using System.Threading.Tasks;
using TicketSystem.Models;

namespace TicketSystem.Services
{
    public interface IEquipoService
    {
        Task<IEnumerable<Equipo>> GetAllEquiposAsync();
        Task<Equipo> GetEquipoByIdAsync(int id);
        Task AddEquipoAsync(Equipo equipo);
        Task UpdateEquipoAsync(Equipo equipo);
        Task DeleteEquipoAsync(int id);
    }
}
