using TheHobbyHub.BL.Models;

namespace TheHobbyHub.BL.Test
{
    [TestClass]
    public class utFriend : utBase
    {
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
                UserId = new UserManager(options).Load().FirstOrDefault().Id,
                CompanyId = new CompanyManager(options).Load().FirstOrDefault().Id

            };

            Guid result = new FriendsManager(options).Insert(friend, true);
            Assert.IsTrue(result > Guid.Empty);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Friends friend = new FriendsManager(options).Load().FirstOrDefault();
            friend.CompanyId = new CompanyManager(options).Load().FirstOrDefault().Id;

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
