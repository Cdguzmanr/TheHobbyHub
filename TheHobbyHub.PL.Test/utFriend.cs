
using Castle.Components.DictionaryAdapter;

namespace TheHobbyHub.PL.Test
{
    [TestClass]
    public class utFriend : utBase<tblFriend>
    {
        [TestMethod]
        public void LoadTest()
        {
            int expected = 3;
            var friends = base.LoadTest();
            Assert.AreEqual(expected, friends.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            tblFriend newRow = new tblFriend();

            newRow.Id = Guid.NewGuid();
            newRow.UserId = base.LoadTest().FirstOrDefault().UserId;
            newRow.CompanyId = base.LoadTest().FirstOrDefault().CompanyId;
            int rowsAffected = InsertTest(newRow);

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblFriend row = base.LoadTest().FirstOrDefault();

            if (row != null)
            {
                row.UserId = base.LoadTest().FirstOrDefault().UserId;
                int rowsAffected = UpdateTest(row);
                Assert.AreEqual(1, rowsAffected);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            tblFriend row = base.LoadTest().FirstOrDefault(x => x.UserId == x.UserId);

            if (row != null)
            {
                int rowsAffected = DeleteTest(row);

                Assert.IsTrue(rowsAffected == 1);
            }


        }
    }
}
