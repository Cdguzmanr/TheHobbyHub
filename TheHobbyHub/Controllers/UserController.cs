using Microsoft.EntityFrameworkCore;
using TheHobbyHub.PL.Data;

namespace TheHobbyHub.Controllers
{
    public class UserController : Controller
    {
        private readonly DbContextOptions<HobbyHubEntities> options;
        public IActionResult Index()
        {
            ViewBag.Title = "List of Users";
            return View( new UserManager(options).Load());
        }
        
        // Insert default values with Seed() function

        public IActionResult Seed()
        {
            //UserManager.Seed();
            return View();
        }

        private void SetUser(User user)
        {

            HttpContext.Session.SetObject("user", user);
            if (user != null)
            {
                HttpContext.Session.SetObject("fullname", "Welcome " + user.FullName);
            }
            else
            {
                HttpContext.Session.SetObject("fullname", string.Empty);
            }
        }

        public IActionResult Logout()
        {
            ViewBag.Title = "Logout";
            SetUser(null);
            return View();
        }

        public IActionResult Login(string returnUrl)
        {
            TempData["returnUrl"] = returnUrl;
            ViewBag.Title = "Login";
            return View();
        }


        [HttpPost]
        public IActionResult Login(User user)
        {
            try
            {
                bool result = new UserManager(options).Login(user); // To-Do: Fix Login
                SetUser(user);

                if (TempData["returnUrl"] != null)
                {
                    return Redirect(TempData["returnUrl"]?.ToString());
                }

                return RedirectToAction(nameof(Index), "Order"); // ALWAYS Change default re-derict page 
            }//TODO: fix the redirect to action for user controller
            catch (Exception ex)
            {
                ViewBag.Title = "Login";
                ViewBag.Error = ex.Message;
                throw;
            }
        }

        // To-Do:Finish Create, Edit, Delete methods
        public IActionResult Create()
        {
            if (Authentication.IsAuthenticated(HttpContext))
            {
                ViewBag.Title = "Create a User";
                return View();
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            }
        }
        [HttpPost]
        public IActionResult Create(User user)
        {
            try
            {
                int result = new UserManager(options).Insert(user);
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
                var item = new UserManager(options).LoadById(id);
                ViewBag.Title = "Edit";
                return View(item);
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            }

        }
        [HttpPost]
        public IActionResult Edit(Guid id, User user, bool rollback = false)
        {
            try
            {
                int result = new UserManager(options).Insert(user);
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
                var item = new UserManager(options).LoadById(id);
                ViewBag.Title = "Delete";
                return View(item);
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            }
        }
        [HttpPost]
        public IActionResult Delete(Guid id, User user, bool rollback = false)
        {
            try
            {
                int result = new UserManager(options).Delete(id, rollback);
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
