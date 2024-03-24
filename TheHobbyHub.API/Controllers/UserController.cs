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
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> logger;
        private readonly DbContextOptions<HobbyHubEntities> options;

        public UserController(ILogger<UserController> logger,
                                DbContextOptions<HobbyHubEntities> options)
        {
            this.options = options;
            this.logger = logger;
            logger.LogWarning("I was here!!!");
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return new UserManager(options).Load();
        }

        [HttpGet("{id}")]
        public User Get(Guid id)
        {
            return new UserManager(options).LoadById(id);
        }

        [HttpPost("{rollback?}")]
        public int Post([FromBody] User user, bool rollback = false)
        {
            try
            {
                return new UserManager(options).Insert(user, rollback);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{id}/{rollback?}")]
        public int Put(Guid id, [FromBody] User user, bool rollback = false)
        {
            try
            {
                return new UserManager(options).Update(user, rollback);
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
                return new UserManager(options).Delete(id, rollback);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
