using Microsoft.AspNetCore.Mvc;
using tb3.Data;
using tb3.models.Entity;

namespace tb3.Controllers
{
    [ApiController]
    [Route("api/tickets/update")]
    public class TicketUpdateController : ControllerBase
    {
        private readonly TkContext _context;

        public TicketUpdateController(TkContext service)
        {
            _context = service;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicket(int id, CreateTicket updatedTicket)
        {
            if (id != updatedTicket.BusNo)
            {
                return BadRequest("BusNo mismatch.");
            }

            var ticket = await _context.CreateTickets.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }

            ticket.Name = updatedTicket.Name;
            ticket.Age = updatedTicket.Age;
            ticket.DateOfJourney = updatedTicket.DateOfJourney;
            ticket.Price = updatedTicket.Price;
            ticket.Email = updatedTicket.Email;

            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
