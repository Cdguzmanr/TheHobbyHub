namespace TheHobbyHub.PL.Test
{
    [TestClass]
    public class utAddress : utBase<tblAddress>
    {
        [TestMethod]
        public void LoadTest()
        {
            int expected = 3;
            var addresses = base.LoadTest();
            Assert.AreEqual(expected, addresses.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            tblAddress newRow = new tblAddress();

            newRow.Id = Guid.NewGuid();
            newRow.PostalAddress = "123 Main ST";
            newRow.City = "Appleton";
            newRow.State = "WI";
            newRow.Zip = "54914";
            int rowsAffected = InsertTest(newRow);

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblAddress row = base.LoadTest().FirstOrDefault();

            if (row != null)
            {
                row.PostalAddress = "YYYYY";
                int rowsAffected = UpdateTest(row);
                Assert.AreEqual(1, rowsAffected);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            tblAddress row = base.LoadTest().FirstOrDefault(x => x.PostalAddress == "Other");

            if (row != null)
            {
                int rowsAffected = DeleteTest(row);

                Assert.IsTrue(rowsAffected == 1);
            }


        }
    }
}
