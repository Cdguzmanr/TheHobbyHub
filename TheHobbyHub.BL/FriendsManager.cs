using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHobbyHub.BL.Models;
using TheHobbyHub.HobbyHub.BL;
using TheHobbyHub.PL.Data;
using TheHobbyHub.PL.Entities;

namespace ThehobbyHub.BL
{
    public class FriendsManager : GenericManager<tblFriend>
    {
        public FriendsManager(DbContextOptions<HobbyHubEntities> options) : base(options)
        {

        }

        public int Insert(Friends Friends, bool rollback = false)
        {
            try
            {
                try
                {
                    tblFriend row = new tblFriend();
                    row.Id = Guid.NewGuid();
                    row.UserId = Friends.UserId;
                    row.CompanyId = Friends.CompanyId;
                    return base.Insert(row, rollback);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Update(Friends company, bool rollback = false)
        {
            try
            {
                try
                {
                    return base.Update(new tblFriend
                    {
                        Id = company.Id,
                        UserId = company.UserId,
                        CompanyId = company.CompanyId,
                    }, rollback);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

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
                .ForEach(c => rows.Add(
                    new Friends
                    {
                        Id = c.Id,
                        UserId = c.UserId,
                        CompanyId = c.CompanyId,
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
                    Friends company = new Friends
                    {
                        Id = row.Id,
                        UserId = row.UserId,
                        CompanyId = row.CompanyId,
                    };
                    return company;
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

        //Possibly add LoadBy UserId & CompanyId

    }
}
