using Microsoft.EntityFrameworkCore;
using TheHobbyHub.PL.Data;

namespace TheHobbyHub.UI.Controllers
{
    public class AddressController : GenericController<Address>
    {
        private readonly DbContextOptions<HobbyHubEntities> options;
        public AddressController(HttpClient httpClient) : base(httpClient) { }
        [HttpGet]
        public IEnumerable<Address> Get()
        {
            return new AddressManager(options).Load();
        }

        [HttpGet("{id}")]
        public Address Get(Guid id)
        {
            return new AddressManager(options).LoadById(id);
        }

        [HttpPost("{rollback?}")]
        public int Post([FromBody] Address address, bool rollback = false)
        {
            return new AddressManager(options).Insert(address, rollback);
        }

        [HttpPut("{id}/{rollback?}")]
        public int Put(Guid id, [FromBody] Address address, bool rollback = false)
        {
            return new AddressManager(options).Update(address, rollback);
        }

        [HttpDelete("{id}/{rollback?}")]
        public int Delete(Guid id, bool rollback = false)
        {
            return new AddressManager(options).Delete(id, rollback);
        }
    }
}
