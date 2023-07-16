using Entities;
using Microsoft.AspNetCore.Mvc;
using School_Core.Models;
using School_Core.Repositories;
using School_Core.Services;

namespace School_Core.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        private readonly IUserRepository _userRepository;
        public StudentController(IStudentRepository studentRepository, IUserRepository userRepository)
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
