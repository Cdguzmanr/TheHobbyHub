using Humanizer.Localisation;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace TheHobbyHub.UI.ViewModels
{
    public class UserVM
    {
        private readonly DbContextOptions<HobbyHubEntities> options;

        public UserVM(DbContextOptions<HobbyHubEntities> options)
        {
            this.options = options;
        }

        public User User { get; set; } = new User();
        public List<Hobby> Hobbys { get; set; } = new List<Hobby>();
        public List<Event> Events { get; set; } = new List<Event>();


        public IFormFile? File { get; set; }

        /*// Working list of Hobbys
        [Required(ErrorMessage = "At least one genre selection is required.")]*/
        public IEnumerable<Guid> HobbyIds { get; set; }  // Multiple Hobbys        



        public UserVM()
        {
            Hobbys = new HobbyManager(options).Load();
            Events = new EventManager(options).Load();
        }

        public UserVM(Guid id)
        {
            Hobbys = new HobbyManager(options).Load();
            Events = new EventManager(options).Load();

            User = new UserManager(options).LoadById(id);
            HobbyIds = User.Hobbys.Select(a => a.Id);
        }




    }
}
