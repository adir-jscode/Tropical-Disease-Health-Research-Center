using Microsoft.AspNetCore.Mvc;
using TDHRC.Context;
using TDHRC.Models;

namespace TDHRC.Controllers
{
    public class AdminController : Controller
    {

        private readonly ILogger<AdminController> _logger;
        private readonly ApplicationDbContext _context;
        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        private void UpdateLayout()
        {
           
           
        }
        public bool IsAdminLoggedIn()
        {
            if (Request.Cookies["Username"] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IActionResult Index()
        {

            if(IsAdminLoggedIn())
            {
                var publications = _context.Publications.ToList();
                ViewBag.Publications = publications;

                var blogs = _context.Blogs.ToList();
                ViewBag.Blogs = blogs;
                return View();
            }
            else
            {
                TempData["error"] = "You need to login first";
                return RedirectToAction("Login", "Home");
            }
            
        }

        

        public IActionResult AddPublication()
        {
            if (IsAdminLoggedIn())
            {
                return View();
            }
            else
            {
                TempData["error"] = "You need to login first";
                return RedirectToAction("Login", "Home");
            }

            
        }

        //Add Publication
        [HttpPost]
        public IActionResult AddPublication(Publications publications)
        {
            if (ModelState.IsValid)
            {
                var publication = new Publications
                {
                   Title = publications.Title,
                    Content = publications.Content,
                    JournalLink = publications.JournalLink,
                    ImageUrl = publications.ImageUrl

                };
                _context.Publications.Add(publication);
                _context.SaveChanges();
                TempData["success"] = "Publication Added Successfully";
                return RedirectToAction("Index");
            }
            return View();
            
        }

        //change password
        public IActionResult ChangePassword()
        {
            if (IsAdminLoggedIn())
            {
                return View();
            }
            else
            {
                TempData["error"] = "You need to login first";
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePassword admin)
        {
            if (ModelState.IsValid)
            {
                var username = Request.Cookies["Username"];
                var oldPassword = admin.OldPassword;
                var newPassword = admin.NewPassword;
                var confirmPassword = admin.ConfirmPassword;

                var user = _context.Admins.Where(a => a.Username == username && a.Password == oldPassword).FirstOrDefault();
                if (user != null)
                {
                    if (newPassword == confirmPassword)
                    {
                        user.Password = newPassword;
                        _context.SaveChanges();
                        TempData["success"] = "Password Changed Successfully";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["error"] = "New Password and Confirm Password does not match";
                        return View();
                    }
                }
                else
                {
                    TempData["error"] = "Old Password is incorrect";
                    return View();
                }
            }
            return View();
        }




        

        //Add Blogs
        public IActionResult AddBlog()
        {
            if (IsAdminLoggedIn())
            {
                return View();
            }
            else
            {
                TempData["error"] = "You need to login first";
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpPost]
        public IActionResult AddBlog(Blogs blogs)
        {
            if (ModelState.IsValid)
            {
                var blog = new Blogs
                {
                    Title = blogs.Title,
                    Author = blogs.Author,
                    Content = blogs.Content,
                    ImageUrl = blogs.ImageUrl
                };
                _context.Blogs.Add(blog);
                _context.SaveChanges();
                TempData["success"] = "Blog Added Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        //delete publication
        public IActionResult DeletePublication(string? id)
        {
            if (IsAdminLoggedIn())
            {
                var publication = _context.Publications.Find(id);
                _context.Publications.Remove(publication);
                _context.SaveChanges();
                TempData["success"] = "Publication Deleted Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "You need to login first";
                return RedirectToAction("Login", "Home");
            }
        }

        //delete blog
        public IActionResult DeleteBlog(string? id)
        {
            if (IsAdminLoggedIn())
            {
                var blog = _context.Blogs.Find(id);
                _context.Blogs.Remove(blog);
                _context.SaveChanges();
                TempData["success"] = "Blog Deleted Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "You need to login first";
                return RedirectToAction("Login", "Home");
            }
        }

        //edit blog
        public IActionResult EditBlog(string? id)
        {
            if (IsAdminLoggedIn())
            {
                var blog = _context.Blogs.Find(id);
                ViewBag.Blog = blog;
                return View(blog);
            }
            else
            {
                TempData["error"] = "You need to login first";
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpPost]
        public IActionResult EditBlog(Blogs blogs)
        {
            if (ModelState.IsValid)
            {
                var blog = _context.Blogs.Find(blogs.Id);
                blog.Title = blogs.Title;
                blog.Author = blogs.Author;
                blog.Content = blogs.Content;
                blog.ImageUrl = blogs.ImageUrl;
                _context.SaveChanges();
                TempData["success"] = "Blog Updated Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        //edit publication
        public IActionResult EditPublication(string? id)
        {
            if (IsAdminLoggedIn())
            {
                var publication = _context.Publications.Find(id);
                ViewBag.Publication = publication;
                return View(publication);
            }
            else
            {
                TempData["error"] = "You need to login first";
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpPost]
        public IActionResult EditPublication(Publications publications)
        {
            if (ModelState.IsValid)
            {
                var publication = _context.Publications.Find(publications.Id);
                publication.Title = publications.Title;
                publication.Content = publications.Content;
                publication.JournalLink = publications.JournalLink;
                publication.ImageUrl = publications.ImageUrl;
                _context.SaveChanges();
                TempData["success"] = "Publication Updated Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

       
    }
}
