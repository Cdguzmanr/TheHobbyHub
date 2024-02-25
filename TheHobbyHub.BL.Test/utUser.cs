
using TheHobbyHub.BL.Models;

namespace TheHobbyHub.BL.Test
{
    [TestClass]
    public class utUser : utBase<User>
    {
        [TestMethod]
        public void LoadTest()
        {
            List<User> companies = new UserManager(options).Load();
            int expected = 3;

            Assert.AreEqual(expected, companies.Count);
        }

        [TestMethod]
        public void InsertTest()
        {
            User user = new User
            {
                Id = Guid.NewGuid(),
                UserName = "Test",
                Password = "Test",
                Email = "Test",
                PhoneNumber = "Test",
                FirstName = "Test",
                LastName = "Test",
                Image = "Test"


            };

            int result = new UserManager(options).Insert(user, true);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            User user = new UserManager(options).Load().FirstOrDefault();
            user.UserName = "Test Update";

            Assert.IsTrue(new UserManager(options).Update(user, true) > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            User user = new UserManager(options).Load().LastOrDefault();

            Assert.IsTrue(new UserManager(options).Delete(user.Id, true) > 0);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            User user = new UserManager(options).Load().LastOrDefault();
            Assert.AreEqual(new UserManager(options).LoadById(user.Id).Id, user.Id);
        }

        //Add Tests for logins
    }
}
