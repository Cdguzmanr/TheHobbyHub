using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThehobbyHub.BL;
using TheHobbyHub.BL.Models;
using TheHobbyHub.PL.Data;

namespace TheHobbyHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendsController : ControllerBase
    {
        private readonly ILogger<FriendsController> logger;
        private readonly DbContextOptions<HobbyHubEntities> options;

        public FriendsController(ILogger<FriendsController> logger,
                                DbContextOptions<HobbyHubEntities> options)
        {
            this.options = options;
            this.logger = logger;
            logger.LogWarning("I was here!!!");
        }

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
            try
            {
                return new FriendsManager(options).Insert(friends, rollback);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{id}/{rollback?}")]
        public int Put(Guid id, [FromBody] Friends friends, bool rollback = false)
        {
            try
            {
                return new FriendsManager(options).Update(friends, rollback);
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
                return new FriendsManager(options).Delete(id, rollback);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
