using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using raspisanie_ngieu.api.Models;
using System.Data;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace raspisanie_ngieu.api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class MobileController : ControllerBase
    {
        private readonly raspisanieContext _context;

        public MobileController(raspisanieContext context)
        {
            _context = context;
        }
        //GET: api/Mobile/15С/Четверг
        [HttpGet("Mobile/{group}/{Day}")]
        public IEnumerable<StoredProcedureModel> GetRaspisanieWithChanges(string group, string day) 
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
            var result = _context.StoredProcedureModels.FromSqlRaw("EXECUTE dbo.[GETraspisanieWithChanges] @Group={0},@Day={1}", Group, Day);
            return result;
        }
        //GET: api/Mobile/15C
        [HttpGet("Mobile/{group}")]
        public IActionResult GetRaspisanieOnWeek(string group)
        {
            var Group = new SqlParameter
            {
                Value = group,
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input,
                ParameterName = "Group"
            };
            var result = new JsonResult(_context.StoredProcedureModels.FromSqlRaw("EXECUTE dbo.[GETraspisanieOnWeek] @Group={0}", Group), new JsonSerializerOptions { PropertyNamingPolicy = null });
            
            return result;
        }
        
    }
}
