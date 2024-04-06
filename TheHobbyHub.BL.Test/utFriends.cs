using TheHobbyHub.BL.Models;
using TheHobbyHub.PL.Entities;

namespace TheHobbyHub.BL.Test
{
    [TestClass]
    public class utFriends : utBase
    {
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
            tblFriend row = new FriendsManager(options).Load().FirstOrDefault();
            Assert.IsTrue(new FriendsManager(options).Delete(row.UserId, row.CompanyId, true) > 0);
        }
    }
}
