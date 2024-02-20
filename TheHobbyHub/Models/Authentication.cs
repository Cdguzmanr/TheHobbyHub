using CG.DVDCentral.UI.Extensions;
using TheHobbyHub.BL.Models;

namespace TheHobbyHub.UI.Models
{
    public class Authentication
    {
        public static bool IsAuthenticated(HttpContext context)
        {
            if (context.Session.GetObject<User>("user") != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
