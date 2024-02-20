namespace TheHobbyHub.UI.Controllers
{
    public class HobbyController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "List of Hobbies";
            return View(/*HobbyManager.Load()*/);
        }
        public IActionResult Details(Guid id)
        {
            var item = /*HobbyManager.LoadById(id)*/ 0;
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
        public IActionResult Create(Hobby hobby)
        {
            try
            {
                int result = /*HobbyManager.Insert(hobby)*/ 0;
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
                var item = /*HobbyManager.LoadById(id)*/ 0;
                ViewBag.Title = "Edit";
                return View(item);
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            }
            
        }
        [HttpPost]
        public IActionResult Edit(Guid id, Hobby hobby, bool rollback = false)
        {
            try
            {
                int result = /*HobbyManager.Insert(hobby, rollback)*/ 0;
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
                var item = /*HobbyManager.LoadById(id)*/ 0;
                ViewBag.Title = "Delete";
                return View(item);
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            }
        }
        [HttpPost]
        public IActionResult Delete(Guid id, Hobby hobby, bool rollback = false)
        {
            try
            {
                int result = /*HobbyManager.Delete(id, rollback)*/ 0;
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
