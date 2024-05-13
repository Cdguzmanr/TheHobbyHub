using Humanizer.Localisation;
using TheHobbyHub.BL.Models;

namespace TheHobbyHub.BL
{
    public class HobbyManager : GenericManager<tblHobby>
    {
        public HobbyManager(DbContextOptions<HobbyHubEntities> options) : base(options)
        {

        }

        public int Insert(Hobby hobby, bool rollback = false)
        {
            try
            {
                try
                {
                    tblHobby row = new tblHobby();
                    row.Id = Guid.NewGuid();
                    row.HobbyName = hobby.HobbyName;
                    row.Description = hobby.Description;
                    row.Type = hobby.Type;
                    row.Image = hobby.Image;
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
        public int Update(Hobby hobby, bool rollback = false)
        {
            try
            {
                try
                {
                    return base.Update(new tblHobby
                    {
                        Id = hobby.Id,
                        HobbyName = hobby.HobbyName,
                        Description = hobby.Description,
                        Type = hobby.Type,
                        //Image = hobby.Image
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
                int results = 0;
                
                using(HobbyHubEntities dc = new HobbyHubEntities(options))
                {
                    IDbContextTransaction transaction = null;
                    if(rollback) transaction = dc.Database.BeginTransaction();

                    tblHobby deleteRow = dc.tblHobbies.FirstOrDefault(x => x.Id == id);

                    if(deleteRow != null)
                    {
                        //Delete all the associated tblUserhobby rows
                        var Userhobbies = dc.tblUserHobbies.Where(u => u.HobbyId == id);
                        dc.tblUserHobbies.RemoveRange(Userhobbies);

                        //Delete all the associated tblEvent rows
                        var Events = dc.tblEvents.Where(e => e.HobbyId == id);
                        dc.tblEvents.RemoveRange(Events);

                        //Remove the hobby
                        dc.tblHobbies.Remove(deleteRow);

                        results = dc.SaveChanges();

                        if (rollback) transaction.Rollback();
                    }
                    else
                    {
                        throw new Exception("Row was not Found");
                    }
                } 
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Hobby> Load()
        {
            try
            {
                List<Hobby> rows = new List<Hobby>();
                base.Load()
                .ForEach(hobby => rows.Add(
                    new Hobby
                    {
                        Id = hobby.Id,
                        HobbyName = hobby.HobbyName,
                        Description = hobby.Description,
                        Type = hobby.Type,
                        //Image = hobby.Image
                    }));
                return rows;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

/*        public List<Hobby> Load(Guid? hobbyId = null)
        {
            try
            {
                List<Hobby> rows = new List<Hobby>();


                base.Load()
                .ForEach(hobby => rows.Add(
                    new Hobby
                    {
                        Id = hobby.Id,
                        HobbyName = hobby.HobbyName,
                        Description = hobby.Description,
                        Type = hobby.Type,
                        //Image = hobby.Image
                    }));


                return rows;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }*/



        public List<Hobby> Load(Guid? userId = null)
        {
            try
            {
                using (HobbyHubEntities dc = new HobbyHubEntities(options))
                {
                    List<Hobby> hobbys = new List<Hobby>();

                    if (userId != null)
                    {
                        var results = (from g in dc.tblHobbies
                                       join mg in dc.tblUserHobbies on g.Id equals mg.HobbyId
                                       where mg.UserId == userId || userId == null
                                       select new
                                       {
                                           g.Id,
                                           g.HobbyName,
                                           g.Description,
                                           g.Type
                                       }).Distinct().ToList();

                        results.ForEach(hobby => hobbys.Add(new Hobby
                        {
                            Id = hobby.Id,
                            HobbyName = hobby.HobbyName,
                            Description = hobby.Description,
                            Type = hobby.Type,

                        }));

                    }
                    else
                    {
                        var results = (from g in dc.tblHobbies
                                       select new
                                       {
                                           g.Id,
                                           g.HobbyName,
                                           g.Description,
                                           g.Type
                                       }).Distinct().ToList();

                        results.ForEach(hobby => hobbys.Add(new Hobby
                        {
                            Id = hobby.Id,
                            HobbyName = hobby.HobbyName,
                            Description = hobby.Description,
                            Type = hobby.Type,
                        }));
                    }

                    return hobbys.OrderBy(g => g.HobbyName).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }






        public Hobby LoadById(Guid id)
        {
            try
            {
                tblHobby row = base.LoadById(id);

                if (row != null)
                {
                    Hobby hobby = new Hobby
                    {
                        Id = row.Id,
                        HobbyName = row.HobbyName,
                        Description = row.Description,
                        //Image = row.Image,
                        Type = row.Type
                    };
                    return hobby;
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
