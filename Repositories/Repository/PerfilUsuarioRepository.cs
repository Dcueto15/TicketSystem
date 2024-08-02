using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketSystem.Models;
using TicketSystem.Repositories.IRepository;

namespace TicketSystem.Data.Repositories
{
    public class PerfilUsuarioRepository : IPerfilUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public PerfilUsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PerfilUsuario>> GetAllPerfilesUsuarioAsync()
        {
            try
            {
                return await _context.PerfilUsuarios.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve user profiles", ex);
            }
        }

        public async Task<PerfilUsuario> GetPerfilUsuarioByIdAsync(int id)
        {
            try
            {
                var perfilUsuario = await _context.PerfilUsuarios.FindAsync(id);
                if (perfilUsuario == null)
                    throw new KeyNotFoundException("User profile not found");
                return perfilUsuario;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve user profile with ID {id}", ex);
            }
        }

        public async Task AddPerfilUsuarioAsync(PerfilUsuario perfilUsuario)
        {
            try
            {
                await _context.PerfilUsuarios.AddAsync(perfilUsuario);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add user profile", ex);
            }
        }

        public async Task UpdatePerfilUsuarioAsync(PerfilUsuario perfilUsuario)
        {
            try
            {
                _context.PerfilUsuarios.Update(perfilUsuario);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update user profile", ex);
            }
        }

        public async Task DeletePerfilUsuarioAsync(int id)
        {
            try
            {
                var perfilUsuario = await GetPerfilUsuarioByIdAsync(id);
                if (perfilUsuario == null)
                    throw new KeyNotFoundException("User profile to delete not found");

                _context.PerfilUsuarios.Remove(perfilUsuario);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete user profile", ex);
            }
        }
    }
}
