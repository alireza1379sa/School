using Entities;
using Microsoft.AspNetCore.Mvc;
using School_Core.Models;
using School_Core.Services;

namespace School_Core.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentRepository _studentRepository;

        private readonly UserRepository _userRepository;
        public StudentController(StudentRepository studentRepository, UserRepository userRepository)
        {
            _studentRepository = studentRepository;
            _userRepository = userRepository;
        }
        public IActionResult Profile(User user)
        {
            ViewBag.UserName = user.UserName;
            user = _userRepository.UserIncludeStudent(user.Id);
            return View(_studentRepository.GetWeeklySchedules(user.Student!.Id));
        }
    }
}
