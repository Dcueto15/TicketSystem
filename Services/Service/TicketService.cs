using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketSystem.Models;
using TicketSystem.Repositories.IRepository;
using TicketSystem.Services.IService;

namespace TicketSystem.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<IEnumerable<Ticket>> GetAllTicketsAsync()
        {
            try
            {
                return await _ticketRepository.GetAllTicketsAsync();
            }
            catch (Exception ex)
            {
                // Log the exception here
                throw new Exception("Service error: Could not retrieve tickets", ex);
            }
        }

        public async Task<Ticket> GetTicketByIdAsync(int id)
        {
            try
            {
                return await _ticketRepository.GetTicketByIdAsync(id);
            }
            catch (KeyNotFoundException ex)
            {
                // Log the exception here
                throw new KeyNotFoundException($"Service error: Ticket with ID {id} not found", ex);
            }
            catch (Exception ex)
            {
                // Log the exception here
                throw new Exception($"Service error: Could not retrieve ticket with ID {id}", ex);
            }
        }

        public async Task AddTicketAsync(Ticket ticket)
        {
            try
            {
                if (ticket == null)
                    throw new ArgumentNullException(nameof(ticket), "Provided ticket is null");

                await _ticketRepository.AddTicketAsync(ticket);
            }
            catch (Exception ex)
            {
                // Log the exception here
                throw new Exception("Service error: Could not add ticket", ex);
            }
        }

        public async Task UpdateTicketAsync(Ticket ticket)
        {
            try
            {
                if (ticket == null)
                    throw new ArgumentNullException(nameof(ticket), "Provided ticket is null");

                await _ticketRepository.UpdateTicketAsync(ticket);
            }
            catch (Exception ex)
            {
                // Log the exception here
                throw new Exception("Service error: Could not update ticket", ex);
            }
        }

        public async Task DeleteTicketAsync(int id)
        {
            try
            {
                var ticket = await _ticketRepository.GetTicketByIdAsync(id);
                if (ticket == null)
                    throw new KeyNotFoundException($"Service error: Ticket to delete with ID {id} not found");

                await _ticketRepository.DeleteTicketAsync(id);
            }
            catch (KeyNotFoundException ex)
            {
                // Log the exception here
                throw new KeyNotFoundException($"Service error: Ticket with ID {id} not found", ex);
            }
            catch (Exception ex)
            {
                // Log the exception here
                throw new Exception("Service error: Could not delete ticket", ex);
            }
        }
    }
}
