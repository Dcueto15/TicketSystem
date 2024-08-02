using System.Collections.Generic;
using System.Threading.Tasks;
using TicketSystem.Models;

namespace TicketSystem.Services
{
    public interface ICombinacionDeColoresService
    {
        Task<IEnumerable<CombinacionDeColores>> GetAllCombinacionesDeColoresAsync();
        Task<CombinacionDeColores> GetCombinacionDeColoresByIdAsync(int id);
        Task AddCombinacionDeColoresAsync(CombinacionDeColores combinacionDeColores);
        Task UpdateCombinacionDeColoresAsync(CombinacionDeColores combinacionDeColores);
        Task DeleteCombinacionDeColoresAsync(int id);
    }
}
