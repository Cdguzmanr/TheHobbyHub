using Mono.TextTemplating;
using TheHobbyHub.BL.Models;

namespace TheHobbyHub.BL
{
    public class FriendsManager : GenericManager<tblFriend>
    {
        public FriendsManager(DbContextOptions<HobbyHubEntities> options) : base(options)
        {

        }

        public Guid Insert(Friends friend, bool rollback = false)
        {
            try
            {
                tblFriend row = new tblFriend();
                row.Id = Guid.NewGuid();
                row.UserId = friend.UserId;
                row.CompanyId = friend.CompanyId;

                return base.Insert(row, rollback);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Update(Friends friend, bool rollback = false)
        {
            try
            {
                return base.Update(new tblFriend
                {
                    Id = friend.Id,
                    UserId = friend.UserId,
                    CompanyId = friend.CompanyId,
                }, rollback);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Delete(Guid id, bool rollback = false)
        {
            try
            {
                return base.Delete(id, rollback);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Friends> Load()
        {
            try
            {
                List<Friends> rows = new List<Friends>();
                base.Load()
                .ForEach(friend => rows.Add(
                    new Friends
                    {
                        Id = friend.Id,
                        UserId = friend.UserId,
                        CompanyId = friend.CompanyId,
                    }));
                return rows;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Friends LoadById(Guid id)
        {
            try
            {
                tblFriend row = base.LoadById(id);

                if (row != null)
                {
                    Friends friend = new Friends
                    {
                        Id = row.Id,
                        UserId = row.UserId,
                        CompanyId = row.CompanyId,
                    };
                    return friend;
                }
                else
                {
                    throw new Exception("Row was not found.");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
