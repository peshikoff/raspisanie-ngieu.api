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

        //GET: api/Mobile/raspisanie/15С/Четверг/group
        [HttpGet("raspisanie/{group}/{day}/group")]
        public IActionResult raspisanie_by_group(string group, string day)
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

            var result = new JsonResult(_context.StoredProcedureModels.FromSqlRaw("EXECUTE dbo.[GETraspisanieByGroup] @Group={0}, @Day={1}", Group, Day), new JsonSerializerOptions { PropertyNamingPolicy = null });

            return result;
        }

        //GET: api/Mobile/raspisanie/61b5f61b-d182-4bce-be1c-fb641933b738/Четверг/teacher
        [HttpGet("raspisanie/{guid}/{day}/teacher")]
        public IActionResult raspisanie_teacher(Guid guid,string day)
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
            var result = new JsonResult(_context.StoredProcedureModels.FromSqlRaw("EXECUTE dbo.[GETraspisanie_teacher] @FIO={0}, @Day={1}", FIO, Day), new JsonSerializerOptions { PropertyNamingPolicy = null });

            return result;
        } 

        //GET: api/Mobile/raspisanie/15С/Четверг/group_all
        [HttpGet("raspisanie/{group}/{day}/group_all")]
        public IActionResult raspisanie_changes_events(string group, string day)
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

        //GET: api/Mobile/raspisanie/61b5f61b-d182-4bce-be1c-fb641933b738/Пятница/teacher_all
        [HttpGet("raspisanie/{guid}/{day}/teacher_all")]
        public IActionResult raspisanie_changes_events_teachers(Guid guid, string day)
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
            var result = new JsonResult(_context.StoredProcedureModels.FromSqlRaw("EXECUTE dbo.[GETraspisanie_changes_events_teachers] @FIO={0}, @Day={1}", FIO, Day), new JsonSerializerOptions { PropertyNamingPolicy = null });

            return result;
        }

        //GET: api/Mobile/changes/15С/Четверг/group
        [HttpGet("changes/{group}/{day}/group")]
        public IActionResult changes_by_group(string group,string day)
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

        //GET: api/Mobile/changes/61b5f61b-d182-4bce-be1c-fb641933b738/Пятница/teacher
        [HttpGet("changes/{guid}/{day}/teacher")]
        public IActionResult changes_teacher(Guid guid, string day)
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
            var result = new JsonResult(_context.StoredProcedureModels.FromSqlRaw("EXECUTE dbo.[GETchanges_teacher] @FIO={0}, @Day={1}", FIO, Day), new JsonSerializerOptions { PropertyNamingPolicy = null });

            return result;
        }
    }
}
