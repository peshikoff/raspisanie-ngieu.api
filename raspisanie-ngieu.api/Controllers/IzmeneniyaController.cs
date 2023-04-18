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
    [Route("api/")]
    [ApiController]
    public class IzmeneniyaController : ControllerBase
    {
        private readonly raspisanieContext _context;

        public IzmeneniyaController(raspisanieContext context)
        {
            _context = context;
        }

        
        //GET : api/Izmeneniya/15С/Четверг
        [HttpGet("Izmeneniya/{group}/{day}")]
        public IEnumerable<StoredProcedureModel> GetChanges(string group, string day)
        {
            var Group = new SqlParameter
            {
                Value = group,
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input,
                ParameterName = "Group"
            };
            var Day = new SqlParameter
            {
                Value = day,
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input,
                ParameterName = "Day"
            };
            var result = _context.StoredProcedureModels.FromSqlRaw("EXECUTE dbo.[GETchangesByGroup] @Group={0},@Day={1}", Group, Day);
            return result;

        }
    }
}
