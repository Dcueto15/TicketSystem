using TicketSystem.Models;

namespace TicketSystem.Repositories.IRepositories
{
    public interface ITicketRepository
    {
        IEnumerable<Ticket> GetAllTickets();
        Ticket GetTicketById(int id);
        void AddTicket(Ticket ticket);
        void UpdateTicket(Ticket ticket);
        void DeleteTicket(int id);
    }
}
