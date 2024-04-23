using TheHobbyHub.BL.Models;
using TheHobbyHub.PL.Entities;

namespace TheHobbyHub.BL.Test
{
    [TestClass]
    public class utFriends : utBase
    {

        [TestMethod]
        public void LoadTest()
        {
            List<Friends> friends = new FriendsManager(options).Load();
            Assert.IsTrue(friends.Count > 0);
        }

        [TestMethod] public void LoadByIdTest()
        {
            Friends friends = new FriendsManager(options).Load().LastOrDefault();
            Assert.AreEqual(new FriendsManager(options).LoadById(friends.Id).Id, friends.Id);
        }

        [TestMethod]
        public void InsertTest()
        {
            Guid userId = new UserManager(options).Load().FirstOrDefault().Id;
            Guid companyId = new CompanyManager(options).Load().FirstOrDefault().Id;
            int result = new FriendsManager(options).Insert(userId, companyId, true);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Friends friend = new FriendsManager(options).Load().LastOrDefault();

            Assert.IsTrue(new FriendsManager(options).Delete(friend.Id, true) > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Friends Friend = new FriendsManager(options).Load().FirstOrDefault();
            Friend.UserId = new UserManager(options).Load().FirstOrDefault().Id;

            Assert.IsTrue(new FriendsManager(options).Update(Friend, true) > 0);
        }
    }
}
