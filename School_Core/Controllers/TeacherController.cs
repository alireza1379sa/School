using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School_Core.Models;
using School_Core.Repositories;
using School_Core.Services;
using System.Linq;

namespace School_Core.Controllers
{
    [Authorize]
    public class TeacherController : Controller
    {
        private readonly IUserRepository _userRepository;

        private readonly ITeacherRepository _teacherRepository;

        private readonly IClassesRepository _classesRepository;

        private readonly IStudentRepository _studentRepository;
        public TeacherController(IUserRepository userRepository, ITeacherRepository teacherRepository, IClassesRepository classesRepository, IStudentRepository studentRepository)
        {
            _userRepository = userRepository;
            _teacherRepository = teacherRepository;
            _classesRepository = classesRepository;
            _studentRepository = studentRepository;
        }

        public IActionResult Profile()
        {
            ViewBag.UserName = User.Identity!.Name;
            User myUser = _userRepository.UserIncludeTeacher(int.Parse(User.Claims.First().Value));
            if (myUser.Teacher != null)
            {
                return View(_teacherRepository.GetClasses(myUser.Teacher!.Id));
            }
            else
            {
                return Redirect("Account/Logout");
            }
            
        }

        public IActionResult ShowStudents(int id)
        {
            return View(_classesRepository.GetStudents(id));
        }

        [HttpGet]
        public IActionResult AssignMark(int id)
        {
            return View(_studentRepository.GetById(id));
        }

        [HttpPost]
        public IActionResult AssignMark(Student student)
        {
            if (ModelState.IsValid)
            {
                _studentRepository.AssignMark(student);
                return RedirectToAction("Profile", "Teacher");
            }
            return View(student);
        }
    }
}
