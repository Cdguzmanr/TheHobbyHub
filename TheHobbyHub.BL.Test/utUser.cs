
using Microsoft.Extensions.Options;
using TheHobbyHub.BL.Models;
using TheHobbyHub.PL.Data;

namespace TheHobbyHub.BL.Test
{
    [TestClass]
    public class utUser : utBase
    {

        [TestInitialize]
        public void Initialize()
        {
            new UserManager(options).Seed();
        }


        [TestMethod]
        public void LoadTest()
        {
            List<User> users = new UserManager(options).Load();
            Assert.IsTrue(users.Count > 0);
        }

        [TestMethod]
        public void InsertTest()
        {
            User user = new User { UserName = "Bill", Password = "A1234", FirstName = "Cypher", LastName = "asd", Email = "arossdads@gmail.com", PhoneNumber = "1112211111", Image = "none" };
            int result = new UserManager(options).Insert(user, true);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void LoginSuccess()
        {
            User user = new User {
                FirstName = "Alex",
                LastName = "Rosas",
                Email = "Alexr@gmail.com",
                UserName = "Arosas",
                Image = "image.jpg",
                PhoneNumber = "2627459097",
                Password = ("test")
            };
            bool result = new UserManager(options).Login(user);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void LoginFail()
        {
            try
            {
                User user = new User { UserName = "Arosas", Password = "A1d234", FirstName = "Alex", LastName = "Rosas", Email = "arosas@gmail.com", PhoneNumber = "1111111111", Image = "none" };
                new UserManager(options).Login(user);
                Assert.Fail();
            }
            catch (LoginFailureException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

    }
    
    //}
    //public class utUser : utBase<User>
    //{


    //    [TestMethod]
    //    public void LoadTest()
    //    {
    //        List<User> companies = new UserManager(options).Load();
    //        int expected = 3;

    //        Assert.AreEqual(expected, companies.Count);
    //    }

    //    [TestMethod]
    //    public void InsertTest()
    //    {
    //        User user = new User
    //        {
    //            Id = Guid.NewGuid(),
    //            UserName = "Test",
    //            Password = "Test",
    //            Email = "Test",
    //            PhoneNumber = "Test",
    //            FirstName = "Test",
    //            LastName = "Test",
    //            Image = "Test"


    //        };

    //        int result = new UserManager(options).Insert(user, true);
    //        Assert.IsTrue(result > 0);
    //    }

    //    [TestMethod]
    //    public void UpdateTest()
    //    {
    //        User user = new UserManager(options).Load().FirstOrDefault();
    //        user.UserName = "Test Update";

    //        Assert.IsTrue(new UserManager(options).Update(user, true) > 0);
    //    }

    //    [TestMethod]
    //    public void DeleteTest()
    //    {
    //        User user = new UserManager(options).Load().LastOrDefault();

    //        Assert.IsTrue(new UserManager(options).Delete(user.Id, true) > 0);
    //    }

    //    [TestMethod]
    //    public void LoadByIdTest()
    //    {
    //        User user = new UserManager(options).Load().LastOrDefault();
    //        Assert.AreEqual(new UserManager(options).LoadById(user.Id).Id, user.Id);
    //    }

    //    //Add Tests for logins
    //}

}
