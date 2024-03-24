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
    public class HobbyController : ControllerBase
    {
        private readonly ILogger<HobbyController> logger;
        private readonly DbContextOptions<HobbyHubEntities> options;

        public HobbyController(ILogger<HobbyController> logger,
                                DbContextOptions<HobbyHubEntities> options)
        {
            this.options = options;
            this.logger = logger;
            logger.LogWarning("I was here!!!");
        }

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
            try
            {
                return new HobbyManager(options).Insert(hobby, rollback);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{id}/{rollback?}")]
        public int Put(Guid id, [FromBody] Hobby hobby, bool rollback = false)
        {
            try
            {
                return new HobbyManager(options).Update(hobby, rollback);
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
                return new HobbyManager(options).Delete(id, rollback);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
