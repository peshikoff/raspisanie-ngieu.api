using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using raspisanie_ngieu.api.Models;

namespace raspisanie_ngieu.api.Controllers
{
    [ApiController]
    [Route("api/Support/")]
   
    public class SupportController : ControllerBase
    {
        private readonly raspisanieContext _context;
        public SupportController(raspisanieContext context)
        {
            _context = context;
        }

        //GET : api/Support/getGroups
        [HttpGet("getGroups")]
        public IEnumerable<Groups> GetGroups()
        { 
            var result = _context.Groups.FromSqlRaw("EXECUTE [dbo].[GetGroups]");
            return result;
        }
        //GET : api/Support/GetCurrentWeek
        [HttpGet("GetCurrentWeek")]
        public IEnumerable<Weeks> GetCurrentWeek()
        {
            var result = _context.Weeks.FromSqlRaw("EXECUTE [dbo].[GetCurrentWeekType]");
            return result;
        }
        //GET: api/Support/GetTeachers
        [HttpGet("GetTeachers")]
        public IEnumerable<Teachers> GetTeachers()
        {
            var result = _context.Teachers.FromSqlRaw("EXECUTE [dbo].[GetTeachers]");
            return result;
        }
    }
}
