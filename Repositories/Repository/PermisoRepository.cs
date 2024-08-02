using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketSystem.Models;
using TicketSystem.Repositories.IRepository;

namespace TicketSystem.Data.Repositories
{
    public class PermisoRepository : IPermisoRepository
    {
        private readonly ApplicationDbContext _context;

        public PermisoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Permiso>> GetAllPermisosAsync()
        {
            try
            {
                return await _context.Permisos.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve permissions", ex);
            }
        }

        public async Task<Permiso> GetPermisoByIdAsync(int perfilId, int usuarioId)
        {
            try
            {
                var permiso = await _context.Permisos.FindAsync(perfilId, usuarioId);
                if (permiso == null)
                    throw new KeyNotFoundException("Permission not found");
                return permiso;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve permission", ex);
            }
        }

        public async Task AddPermisoAsync(Permiso permiso)
        {
            try
            {
                await _context.Permisos.AddAsync(permiso);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add permission", ex);
            }
        }

        public async Task UpdatePermisoAsync(Permiso permiso)
        {
            try
            {
                _context.Permisos.Update(permiso);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update permission", ex);
            }
        }

        public async Task DeletePermisoAsync(int perfilId, int usuarioId)
        {
            try
            {
                var permiso = await GetPermisoByIdAsync(perfilId, usuarioId);
                if (permiso == null)
                    throw new KeyNotFoundException("Permission to delete not found");

                _context.Permisos.Remove(permiso);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete permission", ex);
            }
        }
    }
}
