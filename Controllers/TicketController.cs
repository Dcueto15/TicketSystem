using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TicketSystem.Models;
using TicketSystem.Repositories.IRepository;

namespace TicketSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Asegura que todos los métodos en este controlador requieran autorización
    public class TicketController : ControllerBase
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketController(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTickets()
        {
            try
            {
                var tickets = await _ticketRepository.GetAllTicketsAsync();
                return Ok(tickets);
            }
            catch (Exception ex)
            {
                // Log the exception details here
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicketById(int id)
        {
            try
            {
                var ticket = await _ticketRepository.GetTicketByIdAsync(id);
                if (ticket == null)
                {
                    return NotFound();
                }
                return Ok(ticket);
            }
            catch (Exception ex)
            {
                // Log the exception details here
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket([FromBody] Ticket ticket)
        {
            try
            {
                if (ticket == null)
                {
                    return BadRequest("Ticket data is null.");
                }
                await _ticketRepository.AddTicketAsync(ticket);
                return CreatedAtAction("GetTicketById", new { id = ticket.Id }, ticket);
            }
            catch (Exception ex)
            {
                // Log the exception details here
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicket(int id, [FromBody] Ticket ticket)
        {
            try
            {
                if (ticket == null || ticket.Id != id)
                {
                    return BadRequest("Ticket data is invalid.");
                }

                var dbTicket = await _ticketRepository.GetTicketByIdAsync(id);
                if (dbTicket == null)
                {
                    return NotFound();
                }

                await _ticketRepository.UpdateTicketAsync(ticket);
                return NoContent(); // Or return Ok(ticket);
            }
            catch (Exception ex)
            {
                // Log the exception details here
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            try
            {
                var ticket = await _ticketRepository.GetTicketByIdAsync(id);
                if (ticket == null)
                {
                    return NotFound();
                }
                await _ticketRepository.DeleteTicketAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception details here
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    }
}
