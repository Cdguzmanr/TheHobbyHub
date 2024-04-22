using Mono.TextTemplating;
using System.ComponentModel.Design;
using TheHobbyHub.BL.Models;

namespace TheHobbyHub.BL
{
    public class FriendsManager : GenericManager<tblFriend>
    {
        public FriendsManager(DbContextOptions<HobbyHubEntities> options) : base(options)
        {

        }

        public int Insert(Friends friend, bool rollback = false)
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


        public int Insert(Guid userId, Guid companyId, bool rollback = false)
        {
            try
            {
                tblFriend row = new tblFriend();
                row.Id = Guid.NewGuid();
                row.UserId = userId;
                row.CompanyId = companyId;

                return base.Insert(row, rollback);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Update(Guid userId, Guid companyId, bool rollback = false)
        {
            try
            {
                int results;
                using (HobbyHubEntities dc = new HobbyHubEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblFriend row = dc.tblFriends.FirstOrDefault(r => r.CompanyId == companyId && r.UserId == userId);

                    if (row != null)
                    {
                        row.UserId = userId;
                        row.CompanyId = companyId;

                        results = dc.SaveChanges();
                        if (rollback) transaction.Rollback();
                    }
                    else
                    {
                        throw new Exception("Row was not found.");
                    }
                }
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public int Delete2(Guid companyId, bool rollback = false)
        //{
        //    try
        //    {
        //        int results;
        //        using (HobbyHubEntities dc = new HobbyHubEntities())
        //        {
        //            IDbContextTransaction transaction = null;
        //            if (rollback) transaction = dc.Database.BeginTransaction();

        //            tblFriend row = dc.tblFriends.FirstOrDefault(r => r.Id == companyId);

        //            if (row != null)
        //            {
        //                dc.tblFriends.Remove(row);
        //                results = dc.SaveChanges();
        //                if (rollback) transaction.Rollback();
        //            }
        //            else
        //            {
        //                throw new Exception("Row was not found.");
        //            }
        //        }
        //        return results;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        public int Delete(Guid userId, Guid companyId, bool rollback = false)
        {
            try
            {
                int results;
                using (HobbyHubEntities dc = new HobbyHubEntities(options))
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblFriend row = dc.tblFriends.FirstOrDefault(r => r.UserId == userId && r.CompanyId == companyId);

                    if (row != null)
                    {
                        dc.tblFriends.Remove(row);
                        results = dc.SaveChanges();
                        if (rollback) transaction.Rollback();
                    }
                    else
                    {
                        throw new Exception("Row was not found.");
                    }
                }
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
    }
}
