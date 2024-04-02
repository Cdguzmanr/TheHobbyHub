using Microsoft.EntityFrameworkCore;
using TheHobbyHub.BL.Models;
using TheHobbyHub.PL.Data;

namespace TheHobbyHub.BL.Test
{
    [TestClass]
    public class utFriend : utBase<Friends>
    {
        private readonly DbContextOptions<HobbyHubEntities> options;
        [TestMethod]
        public void LoadTest()
        {
            List<Friends> friends = new FriendsManager(options).Load();
            int expected = 3;

            Assert.AreEqual(expected, friends.Count);
        }

        [TestMethod]
        public void InsertTest()
        {
            Friends friend = new Friends
            {
                Id = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                CompanyId = Guid.NewGuid()

            };

            int result = new FriendsManager(options).Insert(friend, true);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Friends friend = new FriendsManager(options).Load().FirstOrDefault();
            friend.CompanyId = Guid.NewGuid();

            Assert.IsTrue(new FriendsManager(options).Update(friend, true) > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Friends friend = new FriendsManager(options).Load().LastOrDefault();

            Assert.IsTrue(new FriendsManager(options).Delete(friend.Id, true) > 0);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            Friends friend = new FriendsManager(options).Load().LastOrDefault();
            Assert.AreEqual(new FriendsManager(options).LoadById(friend.Id).Id, friend.Id);
        }
    }
}
