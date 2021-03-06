﻿using System.Web.Mvc;
using StudentFollowingSystem.Data.Repositories;
using StudentFollowingSystem.Filters;

namespace StudentFollowingSystem.Controllers
{
    [RoutePrefix("cijfers")]
    public class GradeController : ControllerBase
    {
        private readonly GradeRepository _gradeRepository = new GradeRepository();

        [AuthorizeStudent, Route("overzicht")]
        public ActionResult List()
        {
            // Get all the grades for the currently logged in student.
            var student = Student;
            var grades = _gradeRepository.GetByStudent(student.Id);
            return View(grades);
        }
    }
}
