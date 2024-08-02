using TicketSystem.Models;

namespace TicketSystem.Repositories.IRepositories
{
    public interface IEquipoRepository
    {
        Task<IEnumerable<Equipo>> GetAllEquiposAsync();
        Task<Equipo> GetEquipoByIdAsync(int id);
        Task AddEquipoAsync(Equipo equipo);
        Task UpdateEquipoAsync(Equipo equipo);
        Task DeleteEquipoAsync(int id);
    }
}
