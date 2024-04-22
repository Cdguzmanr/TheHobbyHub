
using System.IO;
using TheHobbyHub.BL.Models;

namespace TheHobbyHub.BL.Test
{
    [TestClass]
    public class utAddress : utBase
    {
        [TestMethod]
        public void LoadTest()
        {
            List<Address> companies = new AddressManager(options).Load();
            int expected = 3;

            Assert.AreEqual(expected, companies.Count);
        }

        [TestMethod]
        public void InsertTest()
        {
            Address address = new Address
            {
                Id = Guid.NewGuid(),
                PostalAddress = "Test",
                City = "Test",
                State = "Test",
                Zip = "Test"
                
            };

            int result = new AddressManager(options).Insert(address, true);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Address address = new AddressManager(options).Load().FirstOrDefault();
            address.City = "Test Update";

            Assert.IsTrue(new AddressManager(options).Update(address, true) > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Address address = new AddressManager(options).Load().FirstOrDefault();

            Assert.IsTrue(new AddressManager(options).Delete(address.Id, true) > 0);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            Address address = new AddressManager(options).Load().FirstOrDefault();
            Assert.AreEqual(new AddressManager(options).LoadById(address.Id).Id, address.Id);
        }
    }
}
