using Microsoft.AspNetCore.Mvc;
using tb3.Data;
using Microsoft.EntityFrameworkCore;
using tb3.models.Entity;

namespace tb3.Controllers
{
    [ApiController]
    [Route("api/tickets/create")]
    public class TicketCreationController : ControllerBase
    {
        private readonly TkContext _context;

        public TicketCreationController(TkContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket(CreateTicket ticket)
        {
            _context.CreateTickets.Add(ticket);
            await _context.SaveChangesAsync();

            
            return CreatedAtAction(
                actionName: "GetTicketById", 
                controllerName: "TicketRetrieval",
                routeValues: new { id = ticket.BusNo },
                value: ticket 
            );
        }
    }
}
