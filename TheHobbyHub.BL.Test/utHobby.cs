
using TheHobbyHub.BL.Models;

namespace TheHobbyHub.BL.Test
{
    [TestClass]
    public class utHobby : utBase
    {
        [TestMethod]
        public void LoadTest()
        {
            List<Hobby> companies = new HobbyManager(options).Load();
            int expected = 3;

            Assert.AreEqual(expected, companies.Count);
        }

        [TestMethod]
        public void InsertTest()
        {
            Hobby hobby = new Hobby
            {
                Id = Guid.NewGuid(),
                HobbyName = "Test",
                Description = "Test",
                Type = "Test",
                Image = "Test"

            };

            int result = new HobbyManager(options).Insert(hobby, true);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Hobby hobby = new HobbyManager(options).Load().FirstOrDefault();
            hobby.Description = "Test Update";

            Assert.IsTrue(new HobbyManager(options).Update(hobby, true) > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Hobby hobby = new HobbyManager(options).Load().LastOrDefault();

            Assert.IsTrue(new HobbyManager(options).Delete(hobby.Id, true) > 0);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            Hobby hobby = new HobbyManager(options).Load().LastOrDefault();
            Assert.AreEqual(new HobbyManager(options).LoadById(hobby.Id).Id, hobby.Id);
        }
    }
}
