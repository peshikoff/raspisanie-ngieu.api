using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using raspisanie_ngieu.api.Models;
using System.Data;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

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
        [HttpGet("raspisanie/{group}/{day}/3")]
        public IActionResult GETraspisanie_changes_events(string group, string day)
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

            var result = new JsonResult(_context.StoredProcedureModels.FromSqlRaw("EXECUTE dbo.[GETraspisanie_changes_events] @Group={0}, @Day={1}", Group, Day), new JsonSerializerOptions { PropertyNamingPolicy = null });

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
        //GET: api/Mobile/raspisanie/F01740F5-B67A-4342-993C-DAF795F8A11D/Четверг
        [HttpGet("raspisanie/{guid}/{day}")]
        public IActionResult GETraspisanie_events_changes_teachers(Guid guid, string day)
        {
            var FIO = new SqlParameter
            {
                Value = guid,
                SqlDbType = SqlDbType.UniqueIdentifier,
                Direction = ParameterDirection.Input,
                ParameterName = "FIO"
            };
            var Day = new SqlParameter
            {
                Value = day,
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input,
                ParameterName = "Day"
            };
            var result = new JsonResult(_context.StoredProcedureModels.FromSqlRaw("EXECUTE dbo.[GETraspisanie_events_changes_teachers] @FIO={0}, @Day={1}", FIO, Day), new JsonSerializerOptions { PropertyNamingPolicy = null });
            
            return result;
        }


    }
}
