using Entities;
using Microsoft.AspNetCore.Mvc;
using School_Core.Models;
using School_Core.Repositories;
using School_Core.Services;

namespace School_Core.Controllers
{
    public class TeacherController : Controller
    {
        private readonly IUserRepository _userRepository;

        private readonly ITeacherRepository _teacherRepository;

        private readonly IClassesRepository  _classesRepository;

        private readonly IStudentRepository  _studentRepository;
        public TeacherController(IUserRepository userRepository, ITeacherRepository teacherRepository, IClassesRepository classesRepository, IStudentRepository studentRepository)
        {
            _userRepository = userRepository;
            _teacherRepository = teacherRepository;
            _classesRepository = classesRepository;
            _studentRepository = studentRepository;
        }
        public IActionResult Profile(User user)
        {
            ViewBag.UserName = user.UserName;
            User myUser = _userRepository.UserIncludeTeacher(user.Id);
            return View(_teacherRepository.GetClasses(myUser.Teacher!.Id));
        }

        public IActionResult ShowStudents(int id)
        {
            return View(_classesRepository.GetStudents(id));
        }

        public IActionResult AssignMark(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public IActionResult AssignMark(int id,int mark)
        {
            int i = id;
            int m = mark;
            if (ModelState.IsValid)
            {
                _studentRepository.AssignMark(id, mark);
                return Redirect("/home/index");
            }
            return View(_studentRepository.GetById(id));
        }
    }
}
