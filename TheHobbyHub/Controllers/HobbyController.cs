using Microsoft.EntityFrameworkCore;
using TheHobbyHub.PL.Data;

namespace TheHobbyHub.UI.Controllers
{
    public class HobbyController : GenericController<Hobby>
    {
        public HobbyController(HttpClient httpClient) : base(httpClient) { }
    }
}
