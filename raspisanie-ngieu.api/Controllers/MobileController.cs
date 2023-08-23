using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using raspisanie_ngieu.api.Models;
using System.Data;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace raspisanie_ngieu.api.Controllers
{
    [ApiController]
    [Route("api/Mobile/")]
    
    public class MobileController : ControllerBase
    {
        private readonly raspisanieContext _context;

        public MobileController(raspisanieContext context)
        {
            _context = context;
        }


        //GET: api/Mobile/raspisanie/15С/Четверг/2
        [HttpGet("raspisanie/{group}/{day}/2")]
        public IActionResult GetRaspisanieWithChanges(string group, string day) 
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

            var result = new JsonResult(_context.StoredProcedureModels.FromSqlRaw("EXECUTE dbo.[GETraspisanieWithChanges] @Group={0}, @Day={1}", Group,Day), new JsonSerializerOptions { PropertyNamingPolicy = null });

            return result;
        }

        //GET: api/Mobile/raspisanie/15С
        [HttpGet("raspisanie/{group}")]
        public IActionResult GetRaspisanieOnWeekByGroup(string group)
        {
            var Group = new SqlParameter
            {
                Value = group,
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input,
                ParameterName = "Group"
            };

            var result = new JsonResult(_context.StoredProcedureModels.FromSqlRaw("EXECUTE dbo.[GETraspisanieOnWeekByGroup] @Group={0}", Group), new JsonSerializerOptions { PropertyNamingPolicy = null });
            
            return result;
        }

        //GET: api/Mobile/raspisanie/15С/Четверг/1
        [HttpGet("raspisanie/{group}/{day}/1")]
        public IActionResult GetRaspisanieByGroup(string group, string day)
        {
            var Group = new SqlParameter
            {
                Value= group,
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

            var result = new JsonResult(_context.StoredProcedureModels.FromSqlRaw("EXECUTE dbo.[GETraspisanieByGroup] @Group={0}, @Day={1}", Group, Day), new JsonSerializerOptions { PropertyNamingPolicy = null });
            
            return result;
        }

        //GET: api/Mobile/changes/15С/Четверг
        [HttpGet("changes/{group}/{day}")]
        public IActionResult GetChangesByGroup(string group,string day)
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

            var result = new JsonResult(_context.StoredProcedureModels.FromSqlRaw("EXECUTE dbo.[GETchangesByGroup] @Group={0}, @Day={1}",Group,Day), new JsonSerializerOptions { PropertyNamingPolicy = null});
            
            return result;
        }
        
    }
}
