using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TDHRC.Context;
using TDHRC.Models;

namespace TDHRC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger,ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Publications()
        {
            //get all publications
           var publications = _context.Publications.ToList();
            return View(publications);
        }

        //Login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginValidate(string username, string password, string IsRememberME)
        {

            var admin = _context.Admins.FirstOrDefault(a => a.Username == username && a.Password == password);
    
            CookieOptions options = new CookieOptions();

            if (admin != null)
            {
                TempData["success"] = "Login Successful";
                if (IsRememberME == "on")
                {
                    options.Expires = DateTime.Now.AddDays(7);
                }
                else
                {
                    options.Expires = DateTime.Now.AddDays(1);
                }
               
                Response.Cookies.Append("Username", admin.Username, options);
                Response.Cookies.Append("AdminId", admin.Id, options);
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                TempData["Error"] = "Credentials Incorrect";
                TempData["Header"] = "Authatication Error";
                return RedirectToAction("Login");
            }
           
        }

        //Logout
        public IActionResult Logout()
        {
            TempData["success"] = "Logout Successful";
            //delete all cookies
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }

            
            return RedirectToAction("Index");
            
        }

            //Forgot Password
            public IActionResult ForgotPassword()
            {
                return View();
            }
        [HttpPost]
        public IActionResult ForgotPassword(string email,string password,string cpassword)
        {
            var admin = _context.Admins.FirstOrDefault(a => a.Email == email);
            if (admin != null)
            {
                if (password == cpassword)
                {
                    admin.Password = password;
                    _context.SaveChanges();
                    TempData["success"] = "Password Changed Successfully";
                    return RedirectToAction("Login");
                }
                else
                {
                    TempData["Error"] = "Password Mismatch";
                    TempData["Header"] = "Password Error";
                    return RedirectToAction("ForgotPassword");
                }
            }
            else
            {
                TempData["Error"] = "Email Not Found";
                TempData["Header"] = "Email Error";
                return RedirectToAction("ForgotPassword");
            }
           
        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Blogs()
        {
            var blog = _context.Blogs.ToList();
            return View(blog);
        }

        //blog details
        public IActionResult BlogDetails(string id)
        {
            var blog = _context.Blogs.FirstOrDefault(b => b.Id == id);
            return View(blog);
        }

        //publication details
        public IActionResult PublicationDetails(string id)
        {
            var publication = _context.Publications.FirstOrDefault(p => p.Id == id);
            return View(publication);
        }

        //Contact
        public IActionResult Contact()
        {
            return View();
        }

        //Donate
        public IActionResult Donate()
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
