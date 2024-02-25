using Microsoft.EntityFrameworkCore;
using TheHobbyHub.BL;
using TheHobbyHub.PL.Data;

namespace TheHobbyHub.UI.Controllers
{
    public class EventController : Controller
    {
        private readonly DbContextOptions<HobbyHubEntities> options;
        public IActionResult Index()
        {
            ViewBag.Title = "List of Events";
            return View(new EventManager(options).Load());
        }
        public IActionResult Details(Guid id)
        {
            var item = new EventManager(options).LoadById(id);
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
        public IActionResult Create(Event _event)
        {
            try
            {
                int result = new EventManager(options).Insert(_event);
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
                var item = new EventManager(options).LoadById(id);
                ViewBag.Title = "Edit";
                return View(item);
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            }

        }
        [HttpPost]
        public IActionResult Edit(Guid id, Event _event, bool rollback = false)
        {
            try
            {
                int result = new EventManager(options).Insert(_event, rollback);
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
                var item = new EventManager(options).LoadById(id);
                ViewBag.Title = "Delete";
                return View(item);
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            }
        }
        [HttpPost]
        public IActionResult Delete(Guid id, Event _event, bool rollback = false)
        {
            try
            {
                int result = new EventManager(options).Delete(id, rollback);
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
