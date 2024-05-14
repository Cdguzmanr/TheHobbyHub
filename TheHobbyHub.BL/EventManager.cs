using Mono.TextTemplating;
using NuGet.Protocol;
using System.Diagnostics.Tracing;
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
                row.EventName = eventt.EventName;
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
                    AddressId = eventt.AddressId,
                    UserId = eventt.UserId,
                    CompanyId = eventt.CompanyId,
                    HobbyId = eventt.HobbyId,
                    EventName = eventt.EventName,
                    Description = eventt.Description,
                    Image = eventt.ImagePath,
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
                                 join h in dc.tblHobbies on e.HobbyId equals h.Id
                                 select new Event
                                 {
                                     Id = e.Id,
                                     AddressId = e.AddressId,
                                     UserId = e.UserId,
                                     CompanyId = e.CompanyId,
                                     HobbyId = e.HobbyId,
                                     Date = e.Date,
                                     EventHobby = h.HobbyName,
                                     Description = e.Description,
                                     EventUser = u.FirstName + " " + u.LastName,
                                     EventPostalAddress = ea.PostalAddress,
                                     EventCity = ea.City,
                                     EventState = ea.State,
                                     EventZip = ea.Zip,
                                     ImagePath = e.Image,
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

                using (HobbyHubEntities dc = new HobbyHubEntities(options))
                {
                    tblEvent row = dc.tblEvents.FirstOrDefault(e => e.Id == id);

                    if (row != null)
                    {
                        Event eventt = new Event()
                        {
                            Id = row.Id,
                            AddressId = row.AddressId,
                            UserId = row.UserId,
                            CompanyId = row.CompanyId,
                            HobbyId = row.HobbyId,
                            Date = row.Date,
                            Description = row.Description,
                            EventHobby = new HobbyManager(options).LoadById(row.HobbyId).HobbyName,
                            EventUser = row.User.FirstName + " " + row.User.LastName,
                            EventPostalAddress = row.Address.PostalAddress,
                            EventCity = row.Address.City,
                            EventState = row.Address.State,
                            EventZip = row.Address.Zip,
                            ImagePath = row.Image
                        };

                        return eventt;
                    }
                    else
                    {
                        throw new Exception("row was not found");
                    }
                }

                
                

                //if (row != null)
                //{
                //    Event eventt = new Event
                //    {
                //        Id = row.Id,
                //        UserId = row.UserId,
                //        CompanyId = row.CompanyId,
                //        HobbyId = row.HobbyId,
                //        Description = row.Description,
                //        ImagePath = row.Image,
                //        AddressId = row.AddressId,
                //        Date = row.Date,
                //    };
                //    return eventt;
                //}
                //else
                //{
                //    throw new Exception("Row was not found.");
                //}

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //public List<Event> LoadByUserId(Guid userId)
        //{
        //    try
        //    {
        //        List<Event> rows = new List<Event>();
        //        using (HobbyHubEntities dc = new HobbyHubEntities(options))
        //        {
        //            var results = (from e in dc.tblEvents
        //                           join eu in dc.tblUsers on e.UserId equals eu.Id
        //                           where e.UserId == userId
        //                           select new Event
        //                           {
        //                               Id = e.Id,
        //                               UserId = e.UserId,
        //                               ImagePath = e.Image,
        //                               Date = e.Date
        //                           }).ToList();
        //            results.ForEach(r => rows.Add(
        //                 new Event
        //                 {
        //                     Id = r.Id,
        //                     AddressId = r.AddressId,
        //                     UserId = r.UserId,
        //                     CompanyId = r.CompanyId,
        //                     HobbyId = r.HobbyId,
        //                     Description = r.Description,
        //                     ImagePath = r.ImagePath,
        //                     Date = r.Date
        //                 }
        //                ));

        //            return rows;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}



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
