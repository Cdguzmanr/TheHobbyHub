
using TheHobbyHub.BL.Models;

namespace TheHobbyHub.BL.Test
{
    [TestClass]
    public class utEvent : utBase
    {
        [TestMethod]
        public void LoadTest()
        {
            List<Event> events = new EventManager(options).Load();
            int expected = 3;

            Assert.AreEqual(expected, events.Count);
        }

        [TestMethod]
        //tt
        public void InsertTest()
        {
            Event @event = new Event
            {
                Id = Guid.NewGuid(),
                UserId = new UserManager(options).Load().FirstOrDefault().Id,
                CompanyId = new CompanyManager(options).Load().FirstOrDefault().Id,
                HobbyId = new HobbyManager(options).Load().FirstOrDefault().Id,
                Description = "description",
                ImagePath = "Test",
                AddressId = new AddressManager(options).Load().FirstOrDefault().Id,
                Date = DateTime.Now

            };

            int result = new EventManager(options).Insert(@event, true);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void LoadByHobbyIdTest()
        {
            Guid hobbyId = new EventManager(options).Load().FirstOrDefault().HobbyId;

            Assert.IsTrue(new EventManager(options).LoadByHobbyId(hobbyId).Count > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Event @event = new EventManager(options).Load().FirstOrDefault();
            @event.Description = "Test Update";

            Assert.IsTrue(new EventManager(options).Update(@event, true) > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Event @event = new EventManager(options).Load().LastOrDefault();

            Assert.IsTrue(new EventManager(options).Delete(@event.Id, true) > 0);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            Event @event = new EventManager(options).Load().LastOrDefault();
            Assert.AreEqual(new EventManager(options).LoadById(@event.Id).Id, @event.Id);
        }
    }
}
