using TheHobbyHub.BL.Models;
using TheHobbyHub.PL.Entities;

namespace TheHobbyHub.BL.Test
{
    [TestClass]
    public class utUserHobby : utBase
    {
        //[TestMethod]
        //public void LoadTest()
        //{
        //    List<UserHobby> hobby = new UserHobbyManager(options).Load();
        //    int expected = 3;

        //    Assert.AreEqual(expected, hobby.Count);
        //}

        [TestMethod]
        public void InsertTest()
        {
            Guid userId = new UserManager(options).Load().FirstOrDefault().Id;
            Guid hobbyId = new HobbyManager(options).Load().FirstOrDefault().Id;
            int result = new UserHobbyManager(options).Insert(userId, hobbyId, true);
            Assert.IsTrue(result > 0);
        }

        //[TestMethod]
        //public void UpdateTest()
        //{
        //    UserHobby hobby = new UserHobbyManager(options).Load().FirstOrDefault();
        //    hobby.HobbyId = new HobbyManager(options).Load().FirstOrDefault().Id;

        //    Assert.IsTrue(new UserHobbyManager(options).Update(hobby, true) > 0);
        //}

        [TestMethod]
        public void DeleteTest()
        {
            tblUserHobby row = new UserHobbyManager(options).Load().FirstOrDefault();
            Assert.IsTrue(new UserHobbyManager(options).Delete(row.UserId, row.HobbyId, true) > 0);
        }

        //[TestMethod]
        //public void LoadByIdTest()
        //{
        //    UserHobby hobby = new UserHobbyManager(options).Load().LastOrDefault();
        //    Assert.AreEqual(new UserHobbyManager(options).LoadById(hobby.Id).Id, hobby.Id);
        //}
    }
}
