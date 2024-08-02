using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketSystem.Models;
using TicketSystem.Repositories.IRepository;

namespace TicketSystem.Services
{
    public class EquipoService : IEquipoService
    {
        private readonly IEquipoRepository _equipoRepository;

        public EquipoService(IEquipoRepository equipoRepository)
        {
            _equipoRepository = equipoRepository;
        }

        public async Task<IEnumerable<Equipo>> GetAllEquiposAsync()
        {
            try
            {
                return await _equipoRepository.GetAllEquiposAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Service error: Failed to retrieve teams", ex);
            }
        }

        public async Task<Equipo> GetEquipoByIdAsync(int id)
        {
            try
            {
                return await _equipoRepository.GetEquipoByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Service error: Failed to retrieve team with ID {id}", ex);
            }
        }

        public async Task AddEquipoAsync(Equipo equipo)
        {
            try
            {
                await _equipoRepository.AddEquipoAsync(equipo);
            }
            catch (Exception ex)
            {
                throw new Exception("Service error: Failed to add team", ex);
            }
        }

        public async Task UpdateEquipoAsync(Equipo equipo)
        {
            try
            {
                await _equipoRepository.UpdateEquipoAsync(equipo);
            }
            catch (Exception ex)
            {
                throw new Exception("Service error: Failed to update team", ex);
            }
        }

        public async Task DeleteEquipoAsync(int id)
        {
            try
            {
                await _equipoRepository.DeleteEquipoAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Service error: Failed to delete team", ex);
            }
        }
    }
}
