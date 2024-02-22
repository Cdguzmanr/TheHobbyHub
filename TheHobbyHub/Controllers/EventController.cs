using Microsoft.EntityFrameworkCore;
using TheHobbyHub.PL.Data;

namespace TheHobbyHub.UI.Controllers
{
    public class EventController : Controller
    {
        private readonly DbContextOptions<HobbyHubEntities> options;
        public IActionResult Index()
        {
            ViewBag.Title = "List of Events";
            return View(/*EventManager.Load()*/);
        }
        public IActionResult Details(Guid id)
        {
            var item = /*EventManager.LoadById(id)*/0;
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
                int result = /*EventManager.Insert(_event)*/0;
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
                var item = /*EventManager.LoadById(id)*/0;
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
                int result = /*EventManager.Insert(_event, rollback)*/0;
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
                var item = /*EventManager.LoadById(id)*/0;
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
                int result = /*EvemtManager.Delete(id, rollback)*/0;
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
