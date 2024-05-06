using Microsoft.EntityFrameworkCore;
using TheHobbyHub.BL;

namespace TheHobbyHub.UI.Controllers
{
    public class FriendsController : Controller
    {
        private readonly DbContextOptions<HobbyHubEntities> options;

        public FriendsController(DbContextOptions<HobbyHubEntities> options)
        {
            this.options = options;
        }


        // Generalized class name
        string className = "Friends";

        public IActionResult Index()
        {

            if (Authentication.IsAuthenticated(HttpContext))
            {
                ViewBag.Title = $"Create new {className}";
                return View(new FriendsManager(options).Load());
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            }


            //ViewBag.Title = $"List of {className}";
            //return View(new FriendsManager(options).Load());
        }
        public IActionResult Details(Guid id)
        {
            var item = new FriendsManager(options).LoadById(id);
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
        public IActionResult Create(Friends friends)
        {
            try
            {
                int result = new FriendsManager(options).Insert(friends);
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
                var item = new FriendsManager(options).LoadById(id);
                ViewBag.Title = "Edit";
                return View(item);
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            }

        }
        [HttpPost]
        public IActionResult Edit(Guid id, Friends friends, bool rollback = false)
        {
            try
            {
                int result = new FriendsManager(options).Insert(friends, rollback);
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
                var item = new FriendsManager(options).LoadById(id);
                ViewBag.Title = $"Delete {className}";
                return View(item);
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            }
        }
        [HttpPost]
        public IActionResult Delete(Guid id, Friends friends, bool rollback = false)
        {
            try
            {
                int result = new FriendsManager(options).Delete(id, rollback);
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
