using Microsoft.AspNetCore.Mvc;
using CollegeAdmin.Core;
using CollegeAdmin.Core.Models;
using CollegeAdmin.Web.Helpers;

namespace CollegeAdmin.Web.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserRepository _userRepo;

        public ProfileController(UserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet] public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _userRepo.GetByEmail(email);
            if (user != null && user.Password == password)
            {
                HttpContext.Session.SetObject("CurrentUser", user);
                return RedirectToAction("Index");
            }
            ViewBag.Error = "Неверный email или пароль";
            return View();
        }

        [HttpGet] public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(string firstName, string lastName, string middleName,
                                      string email, string password, string role)
        {
            if (_userRepo.GetByEmail(email) != null)
            {
                ViewBag.Error = "Пользователь с таким email уже существует";
                return View();
            }

            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                MiddleName = middleName,
                Email = email,
                Password = password,
                Role = role,
                StudentId = role == "Student" ? "" : null,
                PhotoPath = "/images/default-user.png"
            };

            _userRepo.Add(user);
            HttpContext.Session.SetObject("CurrentUser", user);
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var user = HttpContext.Session.GetObject<User>("CurrentUser");
            if (user == null) return RedirectToAction("Login");
            return View(user);
        }

        [HttpPost]
        public IActionResult UpdateProfile(User updatedUser)
        {
            var user = HttpContext.Session.GetObject<User>("CurrentUser");
            if (user == null) return RedirectToAction("Login");

            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            user.MiddleName = updatedUser.MiddleName;
            user.Password = updatedUser.Password;

            _userRepo.Update(user);
            HttpContext.Session.SetObject("CurrentUser", user);
            return RedirectToAction("Index");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("CurrentUser");
            return RedirectToAction("Login");
        }
    }
}



























