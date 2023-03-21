using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using raspisanie_ngieu.api.Models;

namespace raspisanie_ngieu.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IzmeneniyaController : ControllerBase
    {
        private readonly raspisanieContext _context;

        public IzmeneniyaController(raspisanieContext context)
        {
            _context = context;
        }

        // GET: api/Izmeneniya
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Изменения>>> GetИзмененияs()
        {
            return await _context.Измененияs.ToListAsync();
        }

        // GET: api/Izmeneniya/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Изменения>> GetИзменения(Guid id)
        {
            var изменения = await _context.Измененияs.FindAsync(id);

            if (изменения == null)
            {
                return NotFound();
            }

            return изменения;
        }
        

        private bool ИзмененияExists(Guid id)
        {
            return _context.Измененияs.Any(e => e.Guid == id);
        }
    }
}
