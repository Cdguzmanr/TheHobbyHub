using Microsoft.AspNetCore.Http.Extensions;

namespace TheHobbyHub.UI.Controllers
{
    public class CompanyController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "List of Companies";
            return View(/*CompanyManager.Load()*/);
        }
        public IActionResult Details(Guid id)
        {
            var item = /*CompanyManager.LoadById(id)*/0;
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
                int result = /*CompanyManager.Insert(company)*/0;
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
                var item = /*CompanyManager.LoadById(id)*/0;
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
                int result = /*CompanyManager.Insert(company, rollback)*/0;
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
                var item = /*CompanyManager.LoadById(id)*/0;
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
                int result = /*CompanyManager.Delete(id, rollback)*/0;
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
