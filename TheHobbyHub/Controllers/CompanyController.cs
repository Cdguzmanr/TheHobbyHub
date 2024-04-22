using Microsoft.EntityFrameworkCore;
using TheHobbyHub.BL;

namespace TheHobbyHub.UI.Controllers
{
    public class CompanyController : Controller
    {
        private readonly DbContextOptions<HobbyHubEntities> options;

        public CompanyController(DbContextOptions<HobbyHubEntities> options)
        {
            this.options = options;
        }


        // Generalized class name
        string className = "Company";

        public IActionResult Index()
        {
            ViewBag.Title = $"List of {className}";
            return View(new CompanyManager(options).Load());
        }
        public IActionResult Details(Guid id)
        {
            var item = new CompanyManager(options).LoadById(id);
            ViewBag.Title = $"{className} details";
            return View(item);
        }
        public IActionResult Create()
        {
            if (Authentication.IsAuthenticated(HttpContext))
            {
                ViewBag.Title = $"Create new {className}";
                return View();
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            }
        }
        [HttpPost]
        public IActionResult Create(Company company)
        {
            try
            {
                int result = new CompanyManager(options).Insert(company);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IActionResult Edit(Guid id)
        {
            if (Authentication.IsAuthenticated(HttpContext))
            {
                var item = new CompanyManager(options).LoadById(id);
                ViewBag.Title = "Edit";
                return View(item);
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            }

        }
        [HttpPost]
        public IActionResult Edit(Guid id, Company company, bool rollback = false)
        {
            try
            {
                int result = new CompanyManager(options).Insert(company, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                return View();
            }
        }
        public IActionResult Delete(Guid id)
        {
            if (Authentication.IsAuthenticated(HttpContext))
            {
                var item = new CompanyManager(options).LoadById(id);
                ViewBag.Title = $"Delete {className}";
                return View(item);
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            }
        }
        [HttpPost]
        public IActionResult Delete(Guid id, Company company, bool rollback = false)
        {
            try
            {
                int result = new CompanyManager(options).Delete(id, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                return View();
            }
        }
    }
}
