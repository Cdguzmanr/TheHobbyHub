using Microsoft.EntityFrameworkCore;
using TheHobbyHub.PL.Data;

namespace TheHobbyHub.UI.Controllers
{
    public class AddressController : GenericController<Address>
    {
        public AddressController(HttpClient httpClient) : base(httpClient) { }
    }
}
