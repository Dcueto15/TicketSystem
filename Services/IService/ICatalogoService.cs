using System.Collections.Generic;
using System.Threading.Tasks;
using TicketSystem.Models;

namespace TicketSystem.Services
{
    public interface ICatalogoService
    {
        Task<IEnumerable<Catalogo>> GetAllCatalogosAsync();
        Task<Catalogo> GetCatalogoByIdAsync(int id);
        Task AddCatalogoAsync(Catalogo catalogo);
        Task UpdateCatalogoAsync(Catalogo catalogo);
        Task DeleteCatalogoAsync(int id);
    }
}
