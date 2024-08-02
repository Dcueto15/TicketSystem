using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketSystem.Models;
using TicketSystem.Repositories.IRepository;

namespace TicketSystem.Services
{
    public class PermisoService : IPermisoService
    {
        private readonly IPermisoRepository _permisoRepository;

        public PermisoService(IPermisoRepository permisoRepository)
        {
            _permisoRepository = permisoRepository;
        }

        public async Task<IEnumerable<Permiso>> GetAllPermisosAsync()
        {
            try
            {
                return await _permisoRepository.GetAllPermisosAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Service error: Failed to retrieve permissions", ex);
            }
        }

        public async Task<Permiso> GetPermisoByIdAsync(int perfilId, int usuarioId)
        {
            try
            {
                var permiso = await _permisoRepository.GetPermisoByIdAsync(perfilId, usuarioId);
                if (permiso == null)
                    throw new KeyNotFoundException($"No permission found for profile ID {perfilId} and user ID {usuarioId}");
                return permiso;
            }
            catch (KeyNotFoundException)
            {
                throw;  // Rethrow to preserve the stack trace.
            }
            catch (Exception ex)
            {
                throw new Exception("Service error: Failed to retrieve permission", ex);
            }
        }

        public async Task AddPermisoAsync(Permiso permiso)
        {
            try
            {
                if (permiso == null)
                    throw new ArgumentNullException(nameof(permiso), "Provided permission object is null");

                await _permisoRepository.AddPermisoAsync(permiso);
            }
            catch (Exception ex)
            {
                throw new Exception("Service error: Failed to add permission", ex);
            }
        }

        public async Task UpdatePermisoAsync(Permiso permiso)
        {
            try
            {
                if (permiso == null)
                    throw new ArgumentNullException(nameof(permiso), "Provided permission object is null");

                await _permisoRepository.UpdatePermisoAsync(permiso);
            }
            catch (Exception ex)
            {
                throw new Exception("Service error: Failed to update permission", ex);
            }
        }

        public async Task DeletePermisoAsync(int perfilId, int usuarioId)
        {
            try
            {
                var permiso = await GetPermisoByIdAsync(perfilId, usuarioId);
                if (permiso == null)
                    throw new KeyNotFoundException($"Permission to delete not found for profile ID {perfilId} and user ID {usuarioId}");

                await _permisoRepository.DeletePermisoAsync(perfilId, usuarioId);
            }
            catch (KeyNotFoundException)
            {
                throw;  // Rethrow to preserve the stack trace.
            }
            catch (Exception ex)
            {
                throw new Exception("Service error: Failed to delete permission", ex);
            }
        }
    }
}
