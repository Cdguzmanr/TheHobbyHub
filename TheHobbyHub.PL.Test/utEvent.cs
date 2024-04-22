
namespace TheHobbyHub.PL.Test
{
    [TestClass]
    public class utEvent : utBase<tblEvent>
    {
        [TestMethod]
        public void LoadTest()
        {
            int expected = 3;
            var events = base.LoadTest();
            Assert.AreEqual(expected, events.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            tblEvent newRow = new tblEvent();

            newRow.Id = Guid.NewGuid();
            newRow.AddressId = base.LoadTest().FirstOrDefault().AddressId;
            newRow.UserId = base.LoadTest().FirstOrDefault().UserId;
            newRow.CompanyId = base.LoadTest().FirstOrDefault().CompanyId;
            newRow.HobbyId = base.LoadTest().FirstOrDefault().HobbyId;
            newRow.Description = "Event";
            newRow.Image = "none";
            newRow.Date = DateTime.Now;
            int rowsAffected = InsertTest(newRow);

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblEvent row = base.LoadTest().FirstOrDefault();

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
            tblEvent row = base.LoadTest().FirstOrDefault(x => x.Description == "Other");

            if (row != null)
            {
                int rowsAffected = DeleteTest(row);

                Assert.IsTrue(rowsAffected == 1);
            }


        }
    }
}
