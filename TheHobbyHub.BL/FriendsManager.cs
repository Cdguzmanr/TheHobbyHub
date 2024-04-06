﻿using Mono.TextTemplating;
using System.ComponentModel.Design;
using TheHobbyHub.BL.Models;

namespace TheHobbyHub.BL
{
    public class FriendsManager : GenericManager<tblFriend>
    {
        public FriendsManager(DbContextOptions<HobbyHubEntities> options) : base(options)
        {

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
        public int Delete(Guid companyId, bool rollback = false)
        {
            try
            {
                int results;
                using (HobbyHubEntities dc = new HobbyHubEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblFriend row = dc.tblFriends.FirstOrDefault(r => r.Id == companyId);

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
