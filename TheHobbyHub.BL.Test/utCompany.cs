﻿
using TheHobbyHub.BL.Models;

namespace TheHobbyHub.BL.Test
{
    [TestClass]
    public class utCompany : utBase
    {
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
                UserId = new UserManager(options).Load().FirstOrDefault().Id,
                CompanyName = "Test",
                AddressId = new AddressManager(options).Load().FirstOrDefault().Id,
                Description = "Test"
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
            Company companies = new CompanyManager(options).Load().FirstOrDefault(x => x.CompanyName == "Company A");

            Assert.IsTrue(new CompanyManager(options).Delete(companies.Id, true) > 0);
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
            Guid addressId = new CompanyManager(options).Load().FirstOrDefault().AddressId;
            Assert.IsTrue(new CompanyManager(options).LoadByAddressId(addressId).Count > 0);
            //Company company = new CompanyManager(options).Load().LastOrDefault();
            //Assert.AreEqual(new CompanyManager(options).LoadByAddressId(company.AddressId).AddressId, company.AddressId);
        }
    }
}
