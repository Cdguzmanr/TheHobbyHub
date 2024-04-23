
namespace TheHobbyHub.PL.Test
{
    [TestClass]
    public class utHobby : utBase<tblHobby>
    {
        [TestMethod]
        public void LoadTest()
        {
            int expected = 3;
            var hobbys = base.LoadTest();
            Assert.AreEqual(expected, hobbys.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            tblHobby newRow = new tblHobby();

            newRow.Id = Guid.NewGuid();
            newRow.HobbyName = "Gym";
            newRow.Description = "Gymmm";
            newRow.Type = "Indoor";
            //newRow.Image = "none";
            int rowsAffected = InsertTest(newRow);

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblHobby row = base.LoadTest().FirstOrDefault();

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
            tblHobby row = base.LoadTest().FirstOrDefault(x => x.Description == "Other");

            if (row != null)
            {
                int rowsAffected = DeleteTest(row);

                Assert.IsTrue(rowsAffected == 1);
            }


        }
    }
}
