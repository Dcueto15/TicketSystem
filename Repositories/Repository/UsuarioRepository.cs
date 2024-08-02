using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketSystem.Models;
using TicketSystem.Repositories.IRepository;

namespace TicketSystem.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> GetAllUsuariosAsync()
        {
            try
            {
                return await _context.Usuarios.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve users", ex);
            }
        }

        public async Task<Usuario> GetUsuarioByIdAsync(int id)
        {
            try
            {
                var usuario = await _context.Usuarios.FindAsync(id);
                if (usuario == null)
                    throw new KeyNotFoundException("User not found");
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve user with ID {id}", ex);
            }
        }

        public async Task AddUsuarioAsync(Usuario usuario)
        {
            try
            {
                await _context.Usuarios.AddAsync(usuario);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add user", ex);
            }
        }

        public async Task UpdateUsuarioAsync(Usuario usuario)
        {
            try
            {
                _context.Usuarios.Update(usuario);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update user", ex);
            }
        }

        public async Task DeleteUsuarioAsync(int id)
        {
            try
            {
                var usuario = await GetUsuarioByIdAsync(id);
                if (usuario == null)
                    throw new KeyNotFoundException("User to delete not found");

                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete user", ex);
            }
        }

        public async Task<Usuario> LoginAsync(string username, string password)
        {
            try
            {
                var usuario = await _context.Usuarios
                    .FirstOrDefaultAsync(u => u.NombreCompleto == username && u.Key == password);
                if (usuario == null)
                    throw new UnauthorizedAccessException("Invalid username or password");
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to login", ex);
            }
        }
    }
}
