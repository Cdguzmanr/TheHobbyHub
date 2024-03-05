using Microsoft.EntityFrameworkCore;
using TheHobbyHub.PL.Data;
using TheHobbyHub.UI.Controllers;

namespace TheHobbyHub.Controllers
{
    public class UserController : GenericController<User>
    {
        public UserController(HttpClient httpClient) : base(httpClient) { }
    }
}
