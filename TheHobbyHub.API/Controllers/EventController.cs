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
    public class EventController : ControllerBase
    {
        private readonly ILogger<EventController> logger;
        private readonly DbContextOptions<HobbyHubEntities> options;

        public EventController(ILogger<EventController> logger,
                                DbContextOptions<HobbyHubEntities> options)
        {
            this.options = options;
            this.logger = logger;
            logger.LogWarning("I was here!!!");
        }

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

        [HttpPost("{rollback?}")]
        public int Post([FromBody] Event address, bool rollback = false)
        {
            try
            {
                return new EventManager(options).Insert(address, rollback);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{id}/{rollback?}")]
        public int Put(Guid id, [FromBody] Event address, bool rollback = false)
        {
            try
            {
                return new EventManager(options).Update(address, rollback);
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
                return new EventManager(options).Delete(id, rollback);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
