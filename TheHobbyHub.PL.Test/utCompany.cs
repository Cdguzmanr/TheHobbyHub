namespace TheHobbyHub.PL.Test
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
            newRow.Image = "none";
            newRow.UserName = "Anytime Fitness";
            newRow.Password = "RunningMan";
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
                row.UserName = "YYYYY";
                int rowsAffected = UpdateTest(row);
                Assert.AreEqual(1, rowsAffected);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            tblCompany row = base.LoadTest().FirstOrDefault(x => x.UserName == "Other");

            if (row != null)
            {
                int rowsAffected = DeleteTest(row);

                Assert.IsTrue(rowsAffected == 1);
            }


        }
    }
}
