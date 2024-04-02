
using Microsoft.EntityFrameworkCore;
using TheHobbyHub.BL.Models;
using TheHobbyHub.PL.Data;

namespace TheHobbyHub.BL.Test
{
    [TestClass]
    public class utCompany : utBase<Company>
    {
        private readonly DbContextOptions<HobbyHubEntities> options;
        [TestMethod]
        public void LoadTest()
        {
            List<Company> companies = new CompanyManager(options).Load();
            int expected = 3;

            Assert.AreEqual(expected, companies.Count);
        }

        [TestMethod]
        public void InsertTest()
        {
            Company company = new Company
            {
                Id = Guid.NewGuid(),
                CompanyName = "Test",
                AddressId = Guid.NewGuid(),
                UserName = "Test",
                Password = "Test",
                Image = "Test"
            };

            int result = new CompanyManager(options).Insert(company, true);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Company company = new CompanyManager(options).Load().FirstOrDefault();
            company.CompanyName = "Test Update";

            Assert.IsTrue(new CompanyManager(options).Update(company, true) > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Company company = new CompanyManager(options).Load().LastOrDefault();

            Assert.IsTrue(new CompanyManager(options).Delete(company.Id, true) > 0);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            Company company = new CompanyManager(options).Load().LastOrDefault();
            Assert.AreEqual(new CompanyManager(options).LoadById(company.Id).Id, company.Id);
        }

        [TestMethod]
        public void LoadByAddressId()
        {
            Company company = new CompanyManager(options).Load().LastOrDefault();
            Assert.AreEqual(new CompanyManager(options).LoadByAddressId(company.AddressId).AddressId, company.AddressId);
        }
    }
}
