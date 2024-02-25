using Microsoft.EntityFrameworkCore;
using TheHobbyHub.PL.Data;

namespace TheHobbyHub.UI.Controllers
{
    public class CompanyController : Controller
    {
        private readonly DbContextOptions<HobbyHubEntities> options;
        public IActionResult Index()
        {
            ViewBag.Title = "List of Companies";
            return View( new CompanyManager(options).Load());
        }
        public IActionResult Details(Guid id)
        {
            var item = new CompanyManager(options).LoadById(id);
            ViewBag.Title = "Details";
            return View(item);
        }
        public IActionResult Create()
        {
            if (Authentication.IsAuthenticated(HttpContext))
            {
                ViewBag.Title = "Create";
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
                ViewBag.Title = "Delete";
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
