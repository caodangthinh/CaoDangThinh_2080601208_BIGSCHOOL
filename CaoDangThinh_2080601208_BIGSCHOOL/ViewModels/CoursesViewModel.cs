using CaoDangThinh_2080601208_BIGSCHOOL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaoDangThinh_2080601208_BIGSCHOOL.ViewModels
{
    public class CoursesViewModel
    {
        public IEnumerable<Course> UpcomingCourses { get; set; }
        public bool ShowAction { get; set; }
    }
}