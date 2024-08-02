using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketSystem.Models;
using TicketSystem.Repositories.IRepository;

namespace TicketSystem.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<Usuario>> GetAllUsuariosAsync()
        {
            try
            {
                return await _usuarioRepository.GetAllUsuariosAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Service error: Failed to retrieve users", ex);
            }
        }

        public async Task<Usuario> GetUsuarioByIdAsync(int id)
        {
            try
            {
                var usuario = await _usuarioRepository.GetUsuarioByIdAsync(id);
                if (usuario == null)
                    throw new KeyNotFoundException($"No user found with ID {id}");
                return usuario;
            }
            catch (KeyNotFoundException)
            {
                throw;  // Rethrow to preserve the stack trace.
            }
            catch (Exception ex)
            {
                throw new Exception($"Service error: Failed to retrieve user with ID {id}", ex);
            }
        }

        public async Task AddUsuarioAsync(Usuario usuario)
        {
            try
            {
                if (usuario == null)
                    throw new ArgumentNullException(nameof(usuario), "Provided user object is null");

                await _usuarioRepository.AddUsuarioAsync(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Service error: Failed to add user", ex);
            }
        }

        public async Task UpdateUsuarioAsync(Usuario usuario)
        {
            try
            {
                if (usuario == null)
                    throw new ArgumentNullException(nameof(usuario), "Provided user object is null");

                await _usuarioRepository.UpdateUsuarioAsync(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Service error: Failed to update user", ex);
            }
        }

        public async Task DeleteUsuarioAsync(int id)
        {
            try
            {
                var usuario = await GetUsuarioByIdAsync(id);
                if (usuario == null)
                    throw new KeyNotFoundException($"User to delete not found with ID {id}");

                await _usuarioRepository.DeleteUsuarioAsync(id);
            }
            catch (KeyNotFoundException)
            {
                throw;  // Rethrow to preserve the stack trace.
            }
            catch (Exception ex)
            {
                throw new Exception("Service error: Failed to delete user", ex);
            }
        }
    }
}
