
namespace TheHobbyHub.UI.Controllers
{

    // 
    public class CompanyController : Controller
    {
        string className = "Company";

        public IActionResult Index()
        {

            ViewBag.Title = $"List of {className}";
            return View(CompanyManager.Load());
        }





        // Using GenericController
        /*
        public class CompanyController : GenericController<Company>
        {
            public CompanyController(HttpClient httpClient) : base(httpClient) { }

        }
        */
    }
}
