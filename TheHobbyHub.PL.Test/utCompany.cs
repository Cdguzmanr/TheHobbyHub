﻿namespace TheHobbyHub.PL.Test
{
    [TestClass]
    public class utCompany : utBase<tblCompany>
    {
        [TestMethod]
        public void LoadTest()
        {
            int expected = 3;
            var companys = base.LoadTest();
            Assert.AreEqual(expected, companys.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            tblCompany newRow = new tblCompany();

            newRow.Id = Guid.NewGuid();
            newRow.CompanyName = "Anytime Ftiness";
            newRow.UserId = base.LoadTest().FirstOrDefault().UserId;
            newRow.Description = "Anytime Fitness";
            newRow.AddressId = base.LoadTest().FirstOrDefault().AddressId;
            int rowsAffected = InsertTest(newRow);

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblCompany row = base.LoadTest().FirstOrDefault();

            if (row != null)
            {
                row.Description = "YYYYY";
                int rowsAffected = UpdateTest(row);
                Assert.AreEqual(1, rowsAffected);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            tblCompany row = base.LoadTest().FirstOrDefault(x => x.Description == "Other");

            if (row != null)
            {
                int rowsAffected = DeleteTest(row);

                Assert.IsTrue(rowsAffected == 1);
            }


        }
    }
}
