using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School_Core.Models;
using School_Core.Repositories;
using School_Core.Services;

namespace School_Core.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        private readonly IUserRepository _userRepository;
        public StudentController(IStudentRepository studentRepository, IUserRepository userRepository)
        {
            _studentRepository = studentRepository;
            _userRepository = userRepository;
        }

        public IActionResult Profile()
        {
            ViewBag.UserName = User.Identity!.Name;
            User user = _userRepository.UserIncludeStudent(int.Parse(User.Claims.First().Value));
            if (user.Student != null)
            {
                return View(_studentRepository.GetWeeklySchedules(user.Student!.Id));
            }
            else
            {
                return Redirect("/Account/logout");
            }
        }
    }
}
