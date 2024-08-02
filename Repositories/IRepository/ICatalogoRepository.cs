using TicketSystem.Models;

namespace TicketSystem.Repositories.IRepository
{
    public interface ICatalogoRepository
    {
        Task<IEnumerable<Catalogo>> GetAllCatalogosAsync();
        Task<Catalogo> GetCatalogoByIdAsync(int id);
        Task AddCatalogoAsync(Catalogo catalogo);
        Task UpdateCatalogoAsync(Catalogo catalogo);
        Task DeleteCatalogoAsync(int id);
    }
}
