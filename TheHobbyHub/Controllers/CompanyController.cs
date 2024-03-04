using Microsoft.EntityFrameworkCore;
using System.IO;
using TheHobbyHub.PL.Data;

namespace TheHobbyHub.UI.Controllers
{
    public class CompanyController : GenericController<Company>
    {
        public CompanyController(HttpClient httpClient) : base(httpClient) { }

    }
}
