using Microsoft.EntityFrameworkCore;
using TheHobbyHub.BL.Models;

namespace TheHobbyHub.UI.ViewModels
{
    public class EventVM
    {
        private readonly DbContextOptions<HobbyHubEntities> options;

        public EventVM(DbContextOptions<HobbyHubEntities> options)
        {
            this.options = options;
        }
        public IEnumerable<Guid> HobbyIds { get; set; }  // Multiple Hobbys   
        public User User { get; set; } = new User();
        public Company Company { get; set; } = new Company();
        public Address Address { get; set; } = new Address();
        public Event Event { get; set; } = new Event();
        public List<Hobby> Hobbies { get; set; } = new List<Hobby>();
        public EventVM()
        {
            Hobbies = new HobbyManager(options).Load();
        }

        public EventVM(Guid id, DbContextOptions<HobbyHubEntities> options)
        {
            Hobbies = new HobbyManager(options).Load();
            //User = new UserManager(options).LoadById(id);
            Company = new CompanyManager(options).LoadById(id);
            Event = new EventManager(options).LoadById(id);
            HobbyIds = User.Hobbys.Select(a => a.Id);
        }
    }
}
