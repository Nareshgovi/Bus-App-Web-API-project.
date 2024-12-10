using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tb3.Data;

namespace tb3.Controllers
{
    [ApiController]
    [Route("api/tickets/delete")]
    public class TicketDeletionController : ControllerBase
    {
        private readonly TkContext _context;

        public TicketDeletionController(TkContext service)
        {
            _context = service;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var ticket = await _context.CreateTickets.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }

            _context.CreateTickets.Remove(ticket);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
