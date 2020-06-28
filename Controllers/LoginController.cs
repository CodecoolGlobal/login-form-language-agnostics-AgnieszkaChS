using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginForm.DAO;
using LoginForm.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoginForm.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUser _userData;

        public LoginController()
        {
            _userData = new UserDB("localhost", "agnieszkachruszczyksilva", "startthis", "login_form");
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(User user)
        {
            if (_userData.IsEmailRegistered(user.Email) && _userData.GetUserByEmail(user.Email).Pass == user.Pass)
            {
                User loggedUser = _userData.GetUserByEmail(user.Email);
                HttpContext.Session.SetString("loggedUserId", Convert.ToString(loggedUser.Id));
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
    }
}
