using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using raspisanie_ngieu.api.Models;

namespace raspisanie_ngieu.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaspisanieController : ControllerBase
    {
        private readonly raspisanieContext _context;

        public RaspisanieController(raspisanieContext context)
        {
            _context = context;
        }

        // GET: api/Raspisanie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Расписание>>> GetРасписаниеs()
        {
            return await _context.Расписаниеs.ToListAsync();
        }

        


        // GET: api/Raspisanie/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Расписание>> GetРасписаниеs(Guid id)
        {
            var расписание = await _context.Расписаниеs.FindAsync(id);

            if (расписание == null)
            {
                return NotFound();
            }

            return расписание;
        }

        private bool РасписаниеExists(Guid id)
        {
            return _context.Расписаниеs.Any(e => e.Guid == id);
        }
    }
}
