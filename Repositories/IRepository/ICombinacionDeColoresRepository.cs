using TicketSystem.Models;

namespace TicketSystem.Repositories.IRepository
{
    public interface ICombinacionDeColoresRepository
    {
        Task<IEnumerable<CombinacionDeColores>> GetAllCombinacionesDeColoresAsync();
        Task<CombinacionDeColores> GetCombinacionDeColoresByIdAsync(int id);
        Task AddCombinacionDeColoresAsync(CombinacionDeColores combinacionDeColores);
        Task UpdateCombinacionDeColoresAsync(CombinacionDeColores combinacionDeColores);
        Task DeleteCombinacionDeColoresAsync(int id);
    }
}
