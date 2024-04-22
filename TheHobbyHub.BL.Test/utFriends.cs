using TheHobbyHub.BL.Models;
using TheHobbyHub.PL.Entities;

namespace TheHobbyHub.BL.Test
{
    [TestClass]
    public class utFriends : utBase
    {
        private readonly DbContextOptions<HobbyHubEntities> options;
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

        //[TestMethod]
        //public void DeleteTest2()
        //{
        //    tblFriend row = new FriendsManager(options).Load().FirstOrDefault();
        //    Assert.IsTrue(new FriendsManager(options).Delete(row.UserId, row.CompanyId, true) > 0);
        //}
    }
}
