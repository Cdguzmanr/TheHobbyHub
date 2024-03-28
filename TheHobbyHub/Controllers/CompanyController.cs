using Microsoft.EntityFrameworkCore;
using TheHobbyHub.PL.Data;

namespace TheHobbyHub.UI.Controllers
{
    public class CompanyController : GenericController<Company>
    {
        private readonly DbContextOptions<HobbyHubEntities> options;
        public CompanyController(HttpClient httpClient) : base(httpClient) { }
        [HttpGet]
        public IEnumerable<Company> Get()
        {
            return new CompanyManager(options).Load();
        }

        [HttpGet("{id}")]
        public Company Get(Guid id)
        {
            return new CompanyManager(options).LoadById(id);
        }

        [HttpPost("{rollback?}")]
        public int Post([FromBody] Company company, bool rollback = false)
        {
            return new CompanyManager(options).Insert(company, rollback);
        }

        [HttpPut("{id}/{rollback?}")]
        public int Put(Guid id, [FromBody] Company company, bool rollback = false)
        {
            return new CompanyManager(options).Update(company,rollback);
        }

        [HttpDelete("{id}/{rollback?}")]
        public int Delete(Guid id, bool rollback = false)
        {
            return new CompanyManager(options).Delete(id,rollback);
        }
    }
}
