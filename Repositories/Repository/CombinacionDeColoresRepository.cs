using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketSystem.Models;
using TicketSystem.Repositories.IRepository;

namespace TicketSystem.Data.Repositories
{
    public class CombinacionDeColoresRepository : ICombinacionDeColoresRepository
    {
        private readonly ApplicationDbContext _context;

        public CombinacionDeColoresRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CombinacionDeColores>> GetAllCombinacionesDeColoresAsync()
        {
            try
            {
                return await _context.CombinacionDeColores.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve color combinations", ex);
            }
        }

        public async Task<CombinacionDeColores> GetCombinacionDeColoresByIdAsync(int id)
        {
            try
            {
                var combinacion = await _context.CombinacionDeColores.FindAsync(id);
                if (combinacion == null)
                    throw new KeyNotFoundException("Color combination not found");
                return combinacion;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve color combination", ex);
            }
        }

        public async Task AddCombinacionDeColoresAsync(CombinacionDeColores combinacion)
        {
            try
            {
                await _context.CombinacionDeColores.AddAsync(combinacion);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add color combination", ex);
            }
        }

        public async Task UpdateCombinacionDeColoresAsync(CombinacionDeColores combinacion)
        {
            try
            {
                _context.CombinacionDeColores.Update(combinacion);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update color combination", ex);
            }
        }

        public async Task DeleteCombinacionDeColoresAsync(int id)
        {
            try
            {
                var combinacion = await GetCombinacionDeColoresByIdAsync(id);
                if (combinacion == null)
                    throw new KeyNotFoundException("Color combination to delete not found");

                _context.CombinacionDeColores.Remove(combinacion);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete color combination", ex);
            }
        }
    }
}
