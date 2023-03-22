using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
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
        //GET : api/Izmeneniya/15С/Четверг
        [HttpGet("{group}/{day}")]
        public IEnumerable<StoredProcedureModel> GetChanges(string group,  string day)
        {
            var Group = new SqlParameter
            {
                Value = group,
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input,
                ParameterName = "Group"
            };
            var Day = new SqlParameter {
                Value = day,
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input,
                ParameterName = "Day"
            };
            var result = _context.StoredProcedureModels.FromSqlRaw("EXECUTE dbo.[GETchangesByGroup] @Group={0},@Day={1}", Group, Day);
            return result;

        }
        

        private bool ИзмененияExists(Guid id)
        {
            return _context.Измененияs.Any(e => e.Guid == id);
        }
    }
}
