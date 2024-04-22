﻿using Mono.TextTemplating;
using TheHobbyHub.BL.Models;

namespace TheHobbyHub.BL
{
    public class EventManager : GenericManager<tblEvent>
    {
        public EventManager(DbContextOptions<HobbyHubEntities> options) : base(options)
        {

        }

        public int Insert(Event eventt, bool rollback = false)
        {
            try
            {
                tblEvent row = new tblEvent();
                row.UserId = eventt.UserId;
                row.CompanyId = eventt.CompanyId;
                row.HobbyId = eventt.HobbyId;
                row.Description = eventt.Description;
                row.Image = eventt.ImagePath;
                row.AddressId = eventt.AddressId;
                row.Date = eventt.Date;


                return base.Insert(row, rollback);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Update(Event eventt, bool rollback = false)
        {
            try
            {
                return base.Update(new tblEvent
                {
                    Id = eventt.Id,
                    UserId = eventt.UserId,
                    CompanyId = eventt.CompanyId,
                    HobbyId = eventt.HobbyId,
                    Description = eventt.Description,
                    Image = eventt.ImagePath,
                    AddressId = eventt.AddressId,
                    Date = eventt.Date,

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
        public List<Event> Load()
        {
            try
            {
                List<Event> events = new List<Event>();
                using (HobbyHubEntities dc = new HobbyHubEntities(options))
                {
                    events = (from e in dc.tblEvents
                                 join ea in dc.tblAddresses on e.AddressId equals ea.Id
                                 join u in dc.tblUsers on e.UserId equals u.Id
                                 select new Event
                                 {
                                     Id = e.Id,
                                     EventUser = u.FirstName + " " + u.LastName,
                                     AddressId = e.AddressId,
                                     EventPostalAddress = ea.PostalAddress,
                                     EventCity = ea.City,
                                     EventState = ea.State,
                                     EventZip = ea.Zip,
                                     ImagePath = u.Image,
                                 }
                              )
                              .ToList();
                }
                return events;

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
                    Event eventt = new Event
                    {
                        Id = row.Id,
                        UserId = row.UserId,
                        CompanyId = row.CompanyId,
                        HobbyId = row.HobbyId,
                        Description = row.Description,
                        ImagePath = row.Image,
                        AddressId = row.AddressId,
                        Date = row.Date,
                    };
                    return eventt;
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

        public List<Event> LoadByHobbyId(Guid hobbyId)
        {
            try
            {
                List<Event> rows = new List<Event>();
                using (HobbyHubEntities dc = new HobbyHubEntities(options))
                {
                    var results = (from e in dc.tblEvents
                                   join eh in dc.tblHobbies on e.HobbyId equals eh.Id
                                   where e.HobbyId == hobbyId
                                   select new Event
                                   {
                                       Id = e.Id,
                                       AddressId = e.AddressId,
                                       UserId = e.UserId,
                                       CompanyId = e.CompanyId,
                                       HobbyId = e.HobbyId,
                                       Description = e.Description,
                                       ImagePath = e.Image,
                                       Date = e.Date
                                   }).ToList();

                    results.ForEach(r => rows.Add(
                         new Event
                         {
                             Id = r.Id,
                             AddressId = r.AddressId,
                             UserId = r.UserId,
                             CompanyId = r.CompanyId,
                             HobbyId = r.HobbyId,
                             Description = r.Description,
                             ImagePath = r.ImagePath,
                             Date = r.Date
                         }
                        ));

                    return rows;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
