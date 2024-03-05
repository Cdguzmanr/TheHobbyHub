using Microsoft.EntityFrameworkCore;
using ThehobbyHub.BL;
using TheHobbyHub.PL.Data;

namespace TheHobbyHub.UI.Controllers
{
    public class FriendsController : GenericController<Friends>
    {
        public FriendsController(HttpClient httpClient) : base(httpClient) { }
    }
}
