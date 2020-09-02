using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using BeltExam.Models;
using BeltExam.Contexts;

namespace BeltExam.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;

        public HomeController(MyContext context)
        {
            _context = context;
        }
        

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("register")]
        public IActionResult Register(UserForm reg)
        {
            if(ModelState.IsValid)
            {
                if(_context.Users.Any( u => u.Email == reg.Register.Email))
                {
                    ModelState.AddModelError("Register.Email","We already have your data");
                    return View("Index");
                }
                else
                {
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    reg.Register.Password = Hasher.HashPassword(reg.Register, reg.Register.Password);
                    _context.Users.Add(reg.Register);
                    _context.SaveChanges();
                    HttpContext.Session.SetInt32("UserId",reg.Register.UserId);
                    return RedirectToAction ("Dashboard");

                }

            }
            else
            {
                return View("Index");
            }

        }

        private User GetUserInDb()
        {
            return _context.Users.FirstOrDefault( u => u.UserId == HttpContext.Session.GetInt32("UserId"));
            
        }

        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            User userInDb = GetUserInDb();
            if(userInDb != null)
            {
                ViewBag.User = userInDb;
                List<Hobby> AllHobbies = _context.Hobbies
                                                            .Include(m => m.Planner)
                                                            .Include(m => m.Attendees)
                                                            .ThenInclude( f => f.HobbyMember)
                                                            .ToList();
                return View(AllHobbies);
            }
            else
            {
                return RedirectToAction("Logout");
            }
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpPost("login")]
        public IActionResult Login(UserForm log)
        {
            if(ModelState.IsValid)
            {
                User userInDb = _context.Users.FirstOrDefault( u => u.Email == log.Login.LoginEmail);
                if(userInDb != null)
                {
                    var hash = new PasswordHasher<LoginUser>();
                    var result = hash.VerifyHashedPassword(log.Login, userInDb.Password, log.Login.LoginPassword);
                    if(result==0)
                    {
                        ModelState.AddModelError("Login.LoginEmail","no u");
                        ModelState.AddModelError("Login.LoginPassword","no u");
                        return View("Index");
                    }
                    else
                    {
                        HttpContext.Session.SetInt32("UserId", userInDb.UserId);
                        return RedirectToAction ("Dashboard");
                    }
                }
                else
                {
                    ModelState.AddModelError("Login.LoginEmail","no u");
                    ModelState.AddModelError("Login.LoginPassword","no u");
                    return View("Index");
                }
            }
            else
            {
                return View ("Index");
            }
        }
        [HttpGet("new")]

        public IActionResult New()
        {
            User userInDb = GetUserInDb();
            if(userInDb != null)
            {
                ViewBag.User = userInDb;
                return View();
            }
            else
            {
                return RedirectToAction("Logout");
            }
        }

        [HttpPost("create/hobby")]
        public IActionResult CreateHobby(Hobby newHobby)
        {
           User userInDb = GetUserInDb();
            if(userInDb != null)
            {
                if(ModelState.IsValid)
                {
                    newHobby.UserId=userInDb.UserId;
                    _context.Hobbies.Add(newHobby);
                    _context.SaveChanges();
                    return Redirect("/dashboard");
                }
                else
                {
                    return View("New");
                }
            }
            else
            {
                return RedirectToAction("Logout");
            } 
        }

        [HttpGet("cancel/{hobbyId}")]
        public IActionResult Cancel(int hobbyId)
        {
            User userInDb = GetUserInDb();
            if(userInDb != null)
            {
                Hobby cancelling = _context.Hobbies.FirstOrDefault( m => m.HobbyId == hobbyId);
                _context.Hobbies.Remove(cancelling);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            else
            {
                return RedirectToAction("Logout");
            }
        }

        [HttpGet("attending/{hobbyId}")]

        public IActionResult Attending(int hobbyId)
        {
            User userInDb = GetUserInDb();
            if(userInDb != null)
            {
                Guest attending = new Guest();
                attending.UserId = userInDb.UserId;
                attending.HobbyId = hobbyId;
                _context.Guests.Add(attending);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");

            }
            else
            {
                return RedirectToAction("Logout");
            }
            
        }

        [HttpGet("notattending/{hobbyId}")]

        public IActionResult NotAttending(int hobbyId)
        {
            User userInDb = GetUserInDb();
            if(userInDb != null)
            {
                Guest notattending = _context.Guests.FirstOrDefault( f => f.UserId == userInDb.UserId && f.HobbyId == hobbyId);
                _context.Guests.Remove(notattending);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");

            }
            else
            {
                return RedirectToAction("Logout");
            }
            
        }
        [HttpGet("show/{hobbyId}")]

        public IActionResult Show(int hobbyId)
        {
             User userInDb = GetUserInDb();
            if(userInDb != null)
            {
                ViewBag.User = userInDb;
                Hobby show = _context.Hobbies
                    .Include( m => m.Planner)
                    .Include( m => m.Attendees)
                    .ThenInclude( f => f.HobbyMember)
                    .FirstOrDefault(m => m.HobbyId == hobbyId);
                return View(show);
            }
            else
            {
                return RedirectToAction("Logout");
            }
        }  
    }
}