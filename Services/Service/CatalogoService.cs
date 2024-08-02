using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketSystem.Models;
using TicketSystem.Repositories.IRepository;

namespace TicketSystem.Services
{
    public class CatalogoService : ICatalogoService
    {
        private readonly ICatalogoRepository _catalogoRepository;

        public CatalogoService(ICatalogoRepository catalogoRepository)
        {
            _catalogoRepository = catalogoRepository;
        }

        public async Task<IEnumerable<Catalogo>> GetAllCatalogosAsync()
        {
            try
            {
                return await _catalogoRepository.GetAllCatalogosAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Service error: Failed to retrieve catalogs", ex);
            }
        }

        public async Task<Catalogo> GetCatalogoByIdAsync(int id)
        {
            try
            {
                var catalogo = await _catalogoRepository.GetCatalogoByIdAsync(id);
                if (catalogo == null)
                    throw new KeyNotFoundException($"No catalog found with ID {id}");
                return catalogo;
            }
            catch (KeyNotFoundException)
            {
                throw;  // Rethrow to preserve the stack trace.
            }
            catch (Exception ex)
            {
                throw new Exception($"Service error: Failed to retrieve catalog with ID {id}", ex);
            }
        }

        public async Task AddCatalogoAsync(Catalogo catalogo)
        {
            try
            {
                if (catalogo == null)
                    throw new ArgumentNullException(nameof(catalogo), "Provided catalog object is null");

                await _catalogoRepository.AddCatalogoAsync(catalogo);
            }
            catch (Exception ex)
            {
                throw new Exception("Service error: Failed to add catalog", ex);
            }
        }

        public async Task UpdateCatalogoAsync(Catalogo catalogo)
        {
            try
            {
                if (catalogo == null)
                    throw new ArgumentNullException(nameof(catalogo), "Provided catalog object is null");

                await _catalogoRepository.UpdateCatalogoAsync(catalogo);
            }
            catch (Exception ex)
            {
                throw new Exception("Service error: Failed to update catalog", ex);
            }
        }

        public async Task DeleteCatalogoAsync(int id)
        {
            try
            {
                var catalogo = await GetCatalogoByIdAsync(id);
                if (catalogo == null)
                    throw new KeyNotFoundException($"Catalog to delete not found with ID {id}");

                await _catalogoRepository.DeleteCatalogoAsync(id);
            }
            catch (KeyNotFoundException)
            {
                throw;  // Rethrow to preserve the stack trace.
            }
            catch (Exception ex)
            {
                throw new Exception("Service error: Failed to delete catalog", ex);
            }
        }
    }
}
