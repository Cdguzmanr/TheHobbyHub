using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHobbyHub.BL.Models;
using TheHobbyHub.PL.Data;
using TheHobbyHub.PL.Entities;

namespace TheHobbyHub.BL
{
    public class EventManager : GenericManager<tblEvent>
    {
        public EventManager(DbContextOptions<HobbyHubEntities> options) : base(options)
        {

        }

        public int Insert(Event Event, bool rollback = false)
        {
            try
            {
                try
                {
                    tblEvent row = new tblEvent();
                    row.Id = Guid.NewGuid();
                    row.UserId = Event.UserId;
                    row.CompanyId = Event.CompanyId;
                    row.HobbyId = Event.HobbyId;
                    row.Description = Event.Description;
                    row.Image = Event.Image;
                    row.AddressId = Event.AddressId;
                    row.Date = Event.Date;
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
        public int Update(Event Event, bool rollback = false)
        {
            try
            {
                try
                {
                    return base.Update(new tblEvent
                    {
                        Id = Event.Id,
                        Description = Event.Description,
                        CompanyId = Event.CompanyId,
                        UserId = Event.UserId,
                        HobbyId = Event.HobbyId,
                        Image = Event.Image,
                        AddressId = Event.AddressId,
                        Date = Event.Date

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
        public List<Event> Load()
        {
            try
            {
                List<Event> rows = new List<Event>();
                base.Load()
                .ForEach(c => rows.Add(
                    new Event
                    {
                        Id = c.Id,
                        UserId = c.UserId,
                        CompanyId = c.CompanyId,
                        HobbyId = c.HobbyId,
                        Date = c.Date,
                        Description = c.Description,
                        Image = c.Image,
                        AddressId = c.AddressId
                    }));
                return rows;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Event LoadById(Guid id)
        {
            try
            {
                tblEvent row = base.LoadById(id);

                if (row != null)
                {
                    Event Event = new Event
                    {
                        Id = row.Id,
                        UserId = row.UserId,
                        CompanyId = row.CompanyId,
                        HobbyId = row.HobbyId,
                        Date = row.Date,
                        Description = row.Description,
                        Image = row.Image,
                        AddressId = row.AddressId
                    };
                    return Event;
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
