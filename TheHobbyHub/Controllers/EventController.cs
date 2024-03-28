using Microsoft.EntityFrameworkCore;
using TheHobbyHub.PL.Data;

namespace TheHobbyHub.UI.Controllers
{
    public class EventController : Controller
    {
        private readonly DbContextOptions<HobbyHubEntities> options;
        //public EventController(HttpClient httpClient) : base(httpClient) { }
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return new EventManager(options).Load();
        }

        [HttpGet("{id}")]
        public Event Get(Guid id)
        {
            return new EventManager(options).LoadById(id);
        }

        //[HttpPost("{rollback?}")]
        //public int Post([FromBody] Event event, bool rollback)
        //{
        //    return new EventManager(options).Insert(event, rollback);
        //}

        //[HttpPut("{id}/{rollback?}")]
        //public int Put(Guid id, [FromBody] Event event, bool rollback = false)
        //{
        //    return new EventManager(options).Update(event, rollback);
        //}

        //[HttpDelete("{id}/{rollback?}")]
        //public int Delete(Guid id, bool rollback = false)
        //{
        //    return new EventManager(options).Delete(id, rollback);
        //}
    }
}
