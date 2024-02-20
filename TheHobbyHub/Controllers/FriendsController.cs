namespace TheHobbyHub.UI.Controllers
{
    public class FriendsController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "List of Friends";
            return View(/*FriendsManager.Load()*/);
        }
        public IActionResult Details(Guid id)
        {
            var item = /*FriendsManager.LoadById(id)*/0;
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
        public IActionResult Create(Friends friends)
        {
            try
            {
                int result = /*FriendsManager.Insert(friends)*/0;
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
                var item = /*FriendsManager.LoadById(id)*/0;
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
                int result = /*FriendsManager.Insert(friends, rollback)*/0;
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
                var item = /*FriendsManager.LoadById(id)*/0;
                ViewBag.Title = "Delete";
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
                int result = /*FriendsManager.Delete(id, rollback)*/0;
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
