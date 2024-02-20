namespace TheHobbyHub.UI.Controllers
{
    public class AddressController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "List of Addresses";
            return View(/*AddressManager.Load()*/);
        }
        public IActionResult Details(Guid id)
        {
            var item = /*AddressManager.LoadById(id)*/ 0;
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
        public IActionResult Create(Address address)
        {
            try
            {
                int result = /*AddressManager.Insert(address)*/ 0;
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
                var item = /*AddressManager.LoadById(id)*/ 0;
                ViewBag.Title = "Edit";
                return View(item);
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            }

        }
        [HttpPost]
        public IActionResult Edit(Guid id, Address address, bool rollback = false)
        {
            try
            {
                int result = /*AddressManager.Insert(address, rollback)*/ 0;
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
                var item = /*AddressManager.LoadById(id)*/ 0;
                ViewBag.Title = "Delete";
                return View(item);
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            }
        }
        [HttpPost]
        public IActionResult Delete(Guid id, Address address, bool rollback = false)
        {
            try
            {
                int result = /*AddressManager.Delete(id, rollback)*/ 0;
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
