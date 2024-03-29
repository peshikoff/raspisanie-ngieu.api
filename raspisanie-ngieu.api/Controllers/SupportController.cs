﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IEnumerable<Groups> GETgroups()
        { 
            var result = _context.Groups.FromSqlRaw("EXECUTE [dbo].[GetGroups]");
            return result;
        }
        //GET : api/Support/GetCurrentWeek
        [HttpGet("GetCurrentWeek")]
        public IEnumerable<Weeks> GETcurrent_week()
        {
            var result = _context.Weeks.FromSqlRaw("EXECUTE [dbo].[GetCurrentWeekType]");
            return result;
        }
        //GET: api/Support/GetTeachers
        [HttpGet("GetTeachers")]
        public IEnumerable<Teachers> GETteachers()
        {
            var result = _context.Teachers.FromSqlRaw("EXECUTE [dbo].[GetTeachers]");
            return result;
        }
    }
}
