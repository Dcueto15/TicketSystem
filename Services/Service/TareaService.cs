using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketSystem.Models;
using TicketSystem.Repositories.IRepository;

namespace TicketSystem.Services
{
    public class TareaService : ITareaService
    {
        private readonly ITareaRepository _tareaRepository;

        public TareaService(ITareaRepository tareaRepository)
        {
            _tareaRepository = tareaRepository;
        }

        public async Task<IEnumerable<Tarea>> GetAllTareasAsync()
        {
            try
            {
                return await _tareaRepository.GetAllTareasAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Service error: Failed to retrieve tasks", ex);
            }
        }

        public async Task<Tarea> GetTareaByIdAsync(int id)
        {
            try
            {
                var tarea = await _tareaRepository.GetTareaByIdAsync(id);
                if (tarea == null)
                    throw new KeyNotFoundException($"No task found with ID {id}");
                return tarea;
            }
            catch (KeyNotFoundException)
            {
                throw;  // Rethrow to preserve the stack trace.
            }
            catch (Exception ex)
            {
                throw new Exception($"Service error: Failed to retrieve task with ID {id}", ex);
            }
        }

        public async Task AddTareaAsync(Tarea tarea)
        {
            try
            {
                if (tarea == null)
                    throw new ArgumentNullException(nameof(tarea), "Provided task object is null");

                await _tareaRepository.AddTareaAsync(tarea);
            }
            catch (Exception ex)
            {
                throw new Exception("Service error: Failed to add task", ex);
            }
        }

        public async Task UpdateTareaAsync(Tarea tarea)
        {
            try
            {
                if (tarea == null)
                    throw new ArgumentNullException(nameof(tarea), "Provided task object is null");

                await _tareaRepository.UpdateTareaAsync(tarea);
            }
            catch (Exception ex)
            {
                throw new Exception("Service error: Failed to update task", ex);
            }
        }

        public async Task DeleteTareaAsync(int id)
        {
            try
            {
                var tarea = await GetTareaByIdAsync(id);
                if (tarea == null)
                    throw new KeyNotFoundException($"Task to delete not found with ID {id}");

                await _tareaRepository.DeleteTareaAsync(id);
            }
            catch (KeyNotFoundException)
            {
                throw;  // Rethrow to preserve the stack trace.
            }
            catch (Exception ex)
            {
                throw new Exception("Service error: Failed to delete task", ex);
            }
        }
    }
}
