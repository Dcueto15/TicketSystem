using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketSystem.Models;
using TicketSystem.Repositories.IRepository;

namespace TicketSystem.Data.Repositories
{
    public class TareaRepository : ITareaRepository
    {
        private readonly ApplicationDbContext _context;

        public TareaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tarea>> GetAllTareasAsync()
        {
            try
            {
                return await _context.Tareas.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve tasks", ex);
            }
        }

        public async Task<Tarea> GetTareaByIdAsync(int id)
        {
            try
            {
                var tarea = await _context.Tareas.FindAsync(id);
                if (tarea == null)
                    throw new KeyNotFoundException("Task not found");
                return tarea;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve task with ID {id}", ex);
            }
        }

        public async Task AddTareaAsync(Tarea tarea)
        {
            try
            {
                await _context.Tareas.AddAsync(tarea);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add task", ex);
            }
        }

        public async Task UpdateTareaAsync(Tarea tarea)
        {
            try
            {
                _context.Tareas.Update(tarea);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update task", ex);
            }
        }

        public async Task DeleteTareaAsync(int id)
        {
            try
            {
                var tarea = await GetTareaByIdAsync(id);
                if (tarea == null)
                    throw new KeyNotFoundException("Task to delete not found");

                _context.Tareas.Remove(tarea);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete task", ex);
            }
        }
    }
}
