namespace TheHobbyHub.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "List of Users";
            return View(/*UserManager.Load()*/);
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
                //bool result = UserManager.Login(user); // To-Do: Fix Login
                SetUser(user);

                if (TempData["returnUrl"] != null)
                {
                    return Redirect(TempData["returnUrl"]?.ToString());
                }

                return RedirectToAction(nameof(Index), "Order"); // ALWAYS Change default re-derict page 
            }
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
                int result = /* UserManager.Insert(user) */ 0;
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
                var item = /* UserManager.LoadById(id) */ 0;
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
                int result = /* UserManager.Insert(user) */ 0;
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
                var item = /* UserManager.LoadById(id) */ 0;
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
                int result = /* UserManager.Delete(id, rollback) */ 0;
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
