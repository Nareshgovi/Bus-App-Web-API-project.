using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tb3.Data;

namespace tb3.Controllers
{
    [ApiController]
    [Route("api/tickets")]
    public class TicketRetrievalController : ControllerBase
    {
        private readonly TkContext _context;

        public TicketRetrievalController(TkContext service)
        {
            _context = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetTickets()
        {
            var tickets = await _context.CreateTickets.ToListAsync();
            return Ok(tickets);
        }

       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicketById(int id)
        {
            var ticket = await _context.CreateTickets.FindAsync(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(ticket);
        }

    }
}
