using Microsoft.AspNetCore.Mvc;
using TDHRC.Context;

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
           
            return View();
        }

        //Add Publication
        [HttpPost]
        public IActionResult AddPublication(Publications publications)
        {
            if (ModelState.IsValid)
            {
                var publication = new Publications
                {
                   
                    Content = publications.Content,
                    JournalLink = publications.JournalLink
                };
                _context.Publications.Add(publication);
                _context.SaveChanges();
                TempData["success"] = "Publication Added Successfully";
                return RedirectToAction("Index");
            }
            return View();
            
        }

        public IActionResult EditPublication()
        {
            return View();
        }
    }
}
