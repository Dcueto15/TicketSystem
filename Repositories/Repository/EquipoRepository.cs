using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketSystem.Models;
using TicketSystem.Repositories.IRepository;

namespace TicketSystem.Data.Repositories
{
    public class EquipoRepository : IEquipoRepository
    {
        private readonly ApplicationDbContext _context;

        public EquipoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Equipo>> GetAllEquiposAsync()
        {
            try
            {
                return await _context.Equipos.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve teams", ex);
            }
        }

        public async Task<Equipo> GetEquipoByIdAsync(int id)
        {
            try
            {
                var equipo = await _context.Equipos.FindAsync(id);
                if (equipo == null)
                    throw new KeyNotFoundException("Team not found");
                return equipo;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve team with ID {id}", ex);
            }
        }

        public async Task AddEquipoAsync(Equipo equipo)
        {
            try
            {
                await _context.Equipos.AddAsync(equipo);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add team", ex);
            }
        }

        public async Task UpdateEquipoAsync(Equipo equipo)
        {
            try
            {
                _context.Equipos.Update(equipo);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update team", ex);
            }
        }

        public async Task DeleteEquipoAsync(int id)
        {
            try
            {
                var equipo = await GetEquipoByIdAsync(id);
                if (equipo == null)
                    throw new KeyNotFoundException("Team to delete not found");

                _context.Equipos.Remove(equipo);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete team", ex);
            }
        }
    }
}
