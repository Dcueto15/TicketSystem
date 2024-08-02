using TicketSystem.Models;

namespace TicketSystem.Repositories.IRepositories
{
    public interface ITareaRepository
    {
        Task<IEnumerable<Tarea>> GetAllTareasAsync();
        Task<Tarea> GetTareaByIdAsync(int id);
        Task AddTareaAsync(Tarea tarea);
        Task UpdateTareaAsync(Tarea tarea);
        Task DeleteTareaAsync(int id);
    }
}
