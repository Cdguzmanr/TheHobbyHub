using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheHobbyHub.BL;
using TheHobbyHub.BL.Models;
using TheHobbyHub.PL.Data;

namespace TheHobbyHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ILogger<CompanyController> logger;
        private readonly DbContextOptions<HobbyHubEntities> options;

        public CompanyController(ILogger<CompanyController> logger,
                                DbContextOptions<HobbyHubEntities> options)
        {
            this.options = options;
            this.logger = logger;
            logger.LogWarning("I was here!!!");
        }

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
            try
            {
                return new CompanyManager(options).Insert(company, rollback);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{id}/{rollback?}")]
        public int Put(Guid id, [FromBody] Company company, bool rollback = false)
        {
            try
            {
                return new CompanyManager(options).Update(company, rollback);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("{id}/{rollback?}")]
        public int Delete(Guid id, bool rollback = false)
        {
            try
            {
                return new CompanyManager(options).Delete(id, rollback);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
