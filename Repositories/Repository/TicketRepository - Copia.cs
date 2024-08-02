using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketSystem.Models;
using TicketSystem.Repositories.IRepository;

namespace TicketSystem.Data.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ApplicationDbContext _context;

        public TicketRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ticket>> GetAllTicketsAsync()
        {
            try
            {
                return await _context.Tickets.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the exception here
                throw new Exception("Could not retrieve tickets", ex);
            }
        }

        public async Task<Ticket> GetTicketByIdAsync(int id)
        {
            try
            {
                var ticket = await _context.Tickets.FindAsync(id);
                if (ticket == null)
                    throw new KeyNotFoundException("Ticket not found");
                return ticket;
            }
            catch (Exception ex)
            {
                // Log the exception here
                throw new Exception($"Error getting ticket with ID {id}", ex);
            }
        }

        public async Task AddTicketAsync(Ticket ticket)
        {
            try
            {
                await _context.Tickets.AddAsync(ticket);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception here
                throw new Exception("Error adding ticket", ex);
            }
        }

        public async Task UpdateTicketAsync(Ticket ticket)
        {
            try
            {
                _context.Tickets.Update(ticket);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception here
                throw new Exception("Error updating ticket", ex);
            }
        }

        public async Task DeleteTicketAsync(int id)
        {
            try
            {
                var ticket = await GetTicketByIdAsync(id);
                if (ticket == null)
                    throw new KeyNotFoundException("Ticket to delete not found");
                _context.Tickets.Remove(ticket);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception here
                throw new Exception("Error deleting ticket", ex);
            }
        }
    }
}
