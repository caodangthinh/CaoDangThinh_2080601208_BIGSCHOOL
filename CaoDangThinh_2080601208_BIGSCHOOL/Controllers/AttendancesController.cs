using CaoDangThinh_2080601208_BIGSCHOOL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using CaoDangThinh_2080601208_BIGSCHOOL.DTOs;

namespace CaoDangThinh_2080601208_BIGSCHOOL.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _dbContext;

        public AttendancesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto attendanceDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Attendances.Any(a => a.AttendeeId == userId && a.CourseId == attendanceDto.CourseId))
            {
                return BadRequest("The Attendance Already exit");
            }
            var attendace = new Attendance
            {
                CourseId = attendanceDto.CourseId,
                AttendeeId = userId
            };

            _dbContext.Attendances.Add(attendace);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
