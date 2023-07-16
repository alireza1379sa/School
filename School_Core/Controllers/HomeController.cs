using Microsoft.AspNetCore.Mvc;
using School_Core.Models;
using School_Core.Services;
using School_Core.ViewModels;
using System.Diagnostics;

namespace School_Core.Controllers
{
    public class HomeController : Controller
    {

        private readonly UserRepository _userRepository;
        public HomeController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserLogin userLogin)
        {
            if (ModelState.IsValid)
            {
                if (_userRepository.IsExist(userLogin.UserName))
                {
                    User user = _userRepository.GetUserByUsername(userLogin.UserName);
                    if (user.UserTitle!.Title == "Admin")
                    {
                        return Redirect("/Admin/Home/Index");
                    }
                    else if (user.UserTitle.Title == "Student")
                    {
                        return RedirectToAction("Profile", "Student", user);
                    }
                    else if (user.UserTitle.Title == "Teacher")
                    {
                        return RedirectToAction("Profile", "Home", user);
                    }
                }
                else
                {
                    ViewBag.Error = "کاربر مورد نطر یافت نشد";
                }
            }

            return View(userLogin);
        }

        public IActionResult Profile(User user)
        {
            return View("Profile", user);
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