using Microsoft.EntityFrameworkCore;
using TheHobbyHub.PL.Data;

namespace TheHobbyHub.UI.Controllers
{
    public class HobbyController : GenericController<Hobby>
    {
        private readonly DbContextOptions<HobbyHubEntities> options;
        public HobbyController(HttpClient httpClient) : base(httpClient) { }
        [HttpGet]
        public IEnumerable<Hobby> Get()
        {
            return new HobbyManager(options).Load();
        }

        [HttpGet("{id}")]
        public Hobby Get(Guid id)
        {
            return new HobbyManager(options).LoadById(id);
        }

        [HttpPost("{rollback?}")]
        public int Post([FromBody] Hobby hobby, bool rollback = false)
        {
            return new HobbyManager(options).Insert(hobby, rollback);
        }

        [HttpPut("{id}/{rollback?}")]
        public int Put(Guid id, [FromBody] Hobby hobby, bool rollback = false)
        {
            return new HobbyManager(options).Update(hobby, rollback);
        }

        [HttpDelete("{id}/{rollback?}")]
        public int Delete(Guid id, bool rollback = false)
        {
            return new HobbyManager(options).Delete(id, rollback);
        }
    }
}
