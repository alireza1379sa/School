using Microsoft.AspNetCore.Mvc;
using School_Core.Models;
using School_Core.Repositories;
using School_Core.Services;
using School_Core.ViewModels;
using System.Diagnostics;

namespace School_Core.Controllers
{
    public class HomeController : Controller
    {

        private readonly IUserRepository _userRepository;
        public HomeController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            if (User.Identity!.IsAuthenticated)
            {
                User user = _userRepository.FindUserById(int.Parse(User.Claims.First().Value));
                if (user.UserTitle!.Title == "Admin")
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
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
                    return Redirect("/Account/Login");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

        }

        public IActionResult NotAvailable()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}