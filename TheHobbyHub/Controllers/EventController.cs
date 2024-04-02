using Microsoft.EntityFrameworkCore;
using TheHobbyHub.BL;

namespace TheHobbyHub.UI.Controllers
{
    public class EventController : Controller
    {
        private readonly DbContextOptions<HobbyHubEntities> options;

        public EventController(DbContextOptions<HobbyHubEntities> options)
        {
            this.options = options;
        }


        // Generalized class name
        string className = "Event";

        public IActionResult Index()
        {
            ViewBag.Title = $"List of {className}";
            return View(new EventManager(options).Load());
        }
        public IActionResult Details(Guid id)
        {
            var item = new EventManager(options).LoadById(id);
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
        public IActionResult Create(Event hobby)
        {
            try
            {
                Guid result = new EventManager(options).Insert(hobby);
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
        public IActionResult Edit(Guid id, Event hobby, bool rollback = false)
        {
            try
            {
                Guid result = new EventManager(options).Insert(hobby, rollback);
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
                ViewBag.Title = $"Delete {className}";
                return View(item);
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            }
        }
        [HttpPost]
        public IActionResult Delete(Guid id, Event hobby, bool rollback = false)
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
