using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketSystem.Models;
using TicketSystem.Repositories.IRepository;

namespace TicketSystem.Services
{
    public class CombinacionDeColoresService : ICombinacionDeColoresService
    {
        private readonly ICombinacionDeColoresRepository _combinacionDeColoresRepository;

        public CombinacionDeColoresService(ICombinacionDeColoresRepository combinacionDeColoresRepository)
        {
            _combinacionDeColoresRepository = combinacionDeColoresRepository;
        }

        public async Task<IEnumerable<CombinacionDeColores>> GetAllCombinacionesDeColoresAsync()
        {
            try
            {
                return await _combinacionDeColoresRepository.GetAllCombinacionesDeColoresAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Service error: Failed to retrieve color combinations", ex);
            }
        }

        public async Task<CombinacionDeColores> GetCombinacionDeColoresByIdAsync(int id)
        {
            try
            {
                var combinacion = await _combinacionDeColoresRepository.GetCombinacionDeColoresByIdAsync(id);
                if (combinacion == null)
                    throw new KeyNotFoundException($"No color combination found with ID {id}");
                return combinacion;
            }
            catch (KeyNotFoundException)
            {
                throw;  // Rethrow to preserve the stack trace.
            }
            catch (Exception ex)
            {
                throw new Exception($"Service error: Failed to retrieve color combination with ID {id}", ex);
            }
        }

        public async Task AddCombinacionDeColoresAsync(CombinacionDeColores combinacionDeColores)
        {
            try
            {
                if (combinacionDeColores == null)
                    throw new ArgumentNullException(nameof(combinacionDeColores), "Provided color combination object is null");

                await _combinacionDeColoresRepository.AddCombinacionDeColoresAsync(combinacionDeColores);
            }
            catch (Exception ex)
            {
                throw new Exception("Service error: Failed to add color combination", ex);
            }
        }

        public async Task UpdateCombinacionDeColoresAsync(CombinacionDeColores combinacionDeColores)
        {
            try
            {
                if (combinacionDeColores == null)
                    throw new ArgumentNullException(nameof(combinacionDeColores), "Provided color combination object is null");

                await _combinacionDeColoresRepository.UpdateCombinacionDeColoresAsync(combinacionDeColores);
            }
            catch (Exception ex)
            {
                throw new Exception("Service error: Failed to update color combination", ex);
            }
        }

        public async Task DeleteCombinacionDeColoresAsync(int id)
        {
            try
            {
                var combinacion = await GetCombinacionDeColoresByIdAsync(id);
                if (combinacion == null)
                    throw new KeyNotFoundException($"Color combination to delete not found with ID {id}");

                await _combinacionDeColoresRepository.DeleteCombinacionDeColoresAsync(id);
            }
            catch (KeyNotFoundException)
            {
                throw;  // Rethrow to preserve the stack trace.
            }
            catch (Exception ex)
            {
                throw new Exception("Service error: Failed to delete color combination", ex);
            }
        }
    }
}
