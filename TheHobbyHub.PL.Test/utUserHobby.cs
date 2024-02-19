namespace TheHobbyHub.PL.Test
{
    [TestClass]
    public class utUserHobby : utBase<tblUserHobby>
    {
        [TestMethod]
        public void LoadTest()
        {
            int expected = 3;
            var userHobbyies = base.LoadTest();
            Assert.AreEqual(expected, userHobbyies.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            tblUserHobby newRow = new tblUserHobby();

            newRow.Id = Guid.NewGuid();
            newRow.UserId = base.LoadTest().FirstOrDefault().UserId;
            newRow.HobbyId = base.LoadTest().FirstOrDefault().HobbyId;
            int rowsAffected = InsertTest(newRow);

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblUserHobby row = base.LoadTest().FirstOrDefault();

            if (row != null)
            {
                row.HobbyId = base.LoadTest().FirstOrDefault().HobbyId;
                int rowsAffected = UpdateTest(row);
                Assert.AreEqual(1, rowsAffected);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            tblUserHobby row = base.LoadTest().FirstOrDefault(x => x.HobbyId == x.HobbyId);

            if (row != null)
            {
                int rowsAffected = DeleteTest(row);

                Assert.IsTrue(rowsAffected == 1);
            }


        }
    }
}
