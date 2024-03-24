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
    public class AddressController : ControllerBase
    {
        private readonly ILogger<AddressController> logger;
        private readonly DbContextOptions<HobbyHubEntities> options;

        public AddressController(ILogger<AddressController> logger,
                                DbContextOptions<HobbyHubEntities> options)
        {
            this.options = options;
            this.logger = logger;
            logger.LogWarning("I was here!!!");
        }

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
            try
            {
                return new AddressManager(options).Insert(address, rollback);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{id}/{rollback?}")]
        public int Put(Guid id, [FromBody] Address address, bool rollback = false)
        {
            try
            {
                return new AddressManager(options).Update(address, rollback);
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
                return new AddressManager(options).Delete(id, rollback);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
