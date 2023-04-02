using CaoDangThinh_2080601208_BIGSCHOOL.DTOs;
using CaoDangThinh_2080601208_BIGSCHOOL.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CaoDangThinh_2080601208_BIGSCHOOL.Controllers
{
    public class FollowingsController : ApiController
    {
        private readonly ApplicationDbContext _dbcontext;

        public FollowingsController()
        {
            _dbcontext = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto followingDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbcontext.Followings.Any(f => f.FollowerId == userId && f.FolloweeId == followingDto.FolloweeId))
            {
                return BadRequest("The Attendance Already exit");
            }
            var following = new Following
            {
                FollowerId = userId,
                FolloweeId = followingDto.FolloweeId
            };

            _dbcontext.Followings.Add(following);
            _dbcontext.SaveChanges();
            return Ok();
        }
    }
}