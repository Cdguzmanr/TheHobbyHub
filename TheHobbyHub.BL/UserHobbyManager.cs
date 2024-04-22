using Mono.TextTemplating;
using System.ComponentModel.Design;
using TheHobbyHub.BL.Models;

namespace TheHobbyHub.BL
{
    public class UserHobbyManager : GenericManager<tblUserHobby>
    {
        public UserHobbyManager(DbContextOptions<HobbyHubEntities> options) : base(options)
        {

        }

        public int Insert(Guid userId, Guid hobbyId, bool rollback = false)
        {
            try
            {
                tblUserHobby row = new tblUserHobby();
                row.Id = Guid.NewGuid();
                row.UserId = userId;
                row.HobbyId = hobbyId;

                return base.Insert(row, rollback);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Update(Guid userId, Guid hobbyId, bool rollback = false)
        {
            try
            {
                int results;
                using (HobbyHubEntities dc = new HobbyHubEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblUserHobby row = dc.tblUserHobbies.FirstOrDefault(r => r.HobbyId == hobbyId && r.UserId == userId);

                    if (row != null)
                    {
                        row.UserId = userId;
                        row.HobbyId = hobbyId;

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
        public int Delete(Guid userhobbyId, bool rollback = false)
        {
            try
            {
                int results;
                using (HobbyHubEntities dc = new HobbyHubEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblUserHobby row = dc.tblUserHobbies.FirstOrDefault(r => r.Id == userhobbyId);

                    if (row != null)
                    {
                        dc.tblUserHobbies.Remove(row);
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


        public int Delete(Guid userId, Guid hobbyId, bool rollback = false)
        {
            try
            {
                int results;
                using (HobbyHubEntities dc = new HobbyHubEntities(options))
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblUserHobby row = dc.tblUserHobbies.FirstOrDefault(r => r.UserId == userId && r.HobbyId == hobbyId);

                    if (row != null)
                    {
                        dc.tblUserHobbies.Remove(row);
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
        //    public List<UserHobby> Load()
        //    {
        //        try
        //        {
        //            List<UserHobby> rows = new List<UserHobby>();
        //            base.Load()
        //            .ForEach(friend => rows.Add(
        //                new UserHobby
        //                {
        //                    Id = friend.Id,
        //                    UserId = friend.UserId,
        //                    HobbyId = friend.HobbyId,
        //                }));
        //            return rows;

        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }
        //    public UserHobby LoadById(Guid id)
        //    {
        //        try
        //        {
        //            tblUserHobby row = base.LoadById(id);

        //            if (row != null)
        //            {
        //                UserHobby friend = new UserHobby
        //                {
        //                    Id = row.Id,
        //                    UserId = row.UserId,
        //                    HobbyId = row.HobbyId,
        //                };
        //                return friend;
        //            }
        //            else
        //            {
        //                throw new Exception("Row was not found.");
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }

        //}
    }
}
