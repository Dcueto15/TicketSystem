using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketSystem.Models;
using TicketSystem.Repositories.IRepository;

namespace TicketSystem.Services
{
    public class PerfilUsuarioService : IPerfilUsuarioService
    {
        private readonly IPerfilUsuarioRepository _perfilUsuarioRepository;

        public PerfilUsuarioService(IPerfilUsuarioRepository perfilUsuarioRepository)
        {
            _perfilUsuarioRepository = perfilUsuarioRepository;
        }

        public async Task<IEnumerable<PerfilUsuario>> GetAllPerfilesUsuarioAsync()
        {
            try
            {
                return await _perfilUsuarioRepository.GetAllPerfilesUsuarioAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Service error: Failed to retrieve user profiles", ex);
            }
        }

        public async Task<PerfilUsuario> GetPerfilUsuarioByIdAsync(int id)
        {
            try
            {
                return await _perfilUsuarioRepository.GetPerfilUsuarioByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Service error: Failed to retrieve user profile with ID {id}", ex);
            }
        }

        public async Task AddPerfilUsuarioAsync(PerfilUsuario perfilUsuario)
        {
            try
            {
                await _perfilUsuarioRepository.AddPerfilUsuarioAsync(perfilUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Service error: Failed to add user profile", ex);
            }
        }

        public async Task UpdatePerfilUsuarioAsync(PerfilUsuario perfilUsuario)
        {
            try
            {
                await _perfilUsuarioRepository.UpdatePerfilUsuarioAsync(perfilUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Service error: Failed to update user profile", ex);
            }
        }
        public async Task DeletePerfilUsuarioAsync(int id)
        {
            try
            {
                var perfilUsuario = await GetPerfilUsuarioByIdAsync(id);
                if (perfilUsuario == null)
                    throw new KeyNotFoundException($"User profile to delete not found with ID {id}");

                await _perfilUsuarioRepository.DeletePerfilUsuarioAsync(id);
            }
            catch (KeyNotFoundException)
            {
                throw;  // Rethrow the caught exception to preserve the stack trace.
            }
            catch (Exception ex)
            {
                throw new Exception("Service error: Failed to delete user profile", ex);
            }
        }
    }
}