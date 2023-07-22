using Microsoft.AspNetCore.Mvc;
using School_Core.Repositories;
using School_Core.Services;
using School_Core.ViewModels;
using Entities;
using School_Core.Models;
using NuGet.Protocol.Plugins;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace School_Core.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ITeacherRepository _teacherRepository;
        public AccountController(IUserRepository userRepository, ITeacherRepository teacherRepository, IStudentRepository studentRepository)
        {
            _userRepository = userRepository;
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
        }
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(UserSignUp userSignUp)
        {

            if (!ModelState.IsValid)
            {
                return View(userSignUp);
            }
            else
            {
                User user = new User();
                user.UserName = userSignUp.UserName;
                user.Password = userSignUp.Password;
                if (_userRepository.IsExist(userSignUp.UserName))
                {
                    ModelState.AddModelError("UserName", "The username is duplicated");
                    return View(userSignUp);
                }
                else if (_studentRepository.ExistStudentByCode(userSignUp.NationalCode))
                {
                    Student student = _studentRepository.FindStudentByCode(userSignUp.NationalCode);
                    user.Student = student;
                    user.UserTitle_id = _userRepository.FindUserTitleId("Student");
                    _userRepository.Insert(user);
                    _userRepository.Save();
                    return RedirectToAction("Login", "Account");
                }
                else if (_teacherRepository.ExistTeacherByCode(userSignUp.NationalCode))
                {
                    Teacher teacher = _teacherRepository.FindTeacherByCode(userSignUp.NationalCode);
                    user.Teacher = teacher;
                    user.UserTitle_id = _userRepository.FindUserTitleId("Teacher");
                    _userRepository.Insert(user);
                    _userRepository.Save();
                    return RedirectToAction("Login", "Account");
                }
                else if (!_studentRepository.ExistStudentByCode(userSignUp.NationalCode))
                {
                    ModelState.AddModelError("NationalCode", "The NationalCode is not true");
                    return View(userSignUp);
                }
                else if (!_teacherRepository.ExistTeacherByCode(userSignUp.NationalCode))
                {
                    ModelState.AddModelError("NationalCode", "The NationalCode is not true");
                    return View(userSignUp);
                }
                else
                {
                    return NotFound();
                }
            }

        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserLogin userLogin)
        {
            if (!ModelState.IsValid)
            {
                return View(userLogin);
            }
            var user = _userRepository.GetUserForLogin(userLogin.UserName, userLogin.Password);
            if (user == null)
            {
                ModelState.AddModelError("UserName", "The UserName dose not exist");
                return View(userLogin);
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role,user.UserTitle!.Title)
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            var properties = new AuthenticationProperties
            {
                IsPersistent = userLogin.RememberMe
            };

            HttpContext.SignInAsync(principal, properties);

            if (user.UserTitle.Title == "Admin")
            {
                return Redirect("/Admin/Home/Index");
            }
            else if (user.UserTitle.Title == "Teacher")
            {
                return RedirectToAction("Profile", "Teacher");
            }
            else if (user.UserTitle.Title == "Student")
            {
                return RedirectToAction("Profile", "Student");
            }
            else
            {
                return Redirect("/");
            }
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Account/Login");
        }

    }
}
