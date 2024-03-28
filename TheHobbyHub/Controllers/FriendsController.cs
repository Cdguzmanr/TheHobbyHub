using Microsoft.EntityFrameworkCore;
using ThehobbyHub.BL;
using TheHobbyHub.PL.Data;

namespace TheHobbyHub.UI.Controllers
{
    public class FriendsController : GenericController<Friends>
    {
        private readonly DbContextOptions<HobbyHubEntities> options;
        public FriendsController(HttpClient httpClient) : base(httpClient) { }
        [HttpGet]
        public IEnumerable<Friends> Get()
        {
            return new FriendsManager(options).Load();
        }

        [HttpGet("{id}")]
        public Friends Get(Guid id)
        {
            return new FriendsManager(options).LoadById(id);
        }

        [HttpPost("{rollback?}")]
        public int Post([FromBody] Friends friends, bool rollback = false)
        {
            return new FriendsManager(options).Insert(friends, rollback);
        }

        [HttpPut("{id}/{rollback?}")]
        public int Put(Guid id, [FromBody] Friends friends, bool rollback = false)
        {
            return new FriendsManager(options).Update(friends, rollback);
        }

        [HttpDelete("{id}/{rollback?}")]
        public int Delete(Guid id, bool rollback = false)
        {
            return new FriendsManager(options).Delete(id, rollback);
        }
    }
}
