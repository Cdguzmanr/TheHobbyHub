namespace TheHobbyHub.BL
{
    public class HobbyManager : GenericManager<tblHobby>
    {
        public HobbyManager(DbContextOptions<HobbyHubEntities> options) : base(options)
        {

        }

        public int Insert(Hobby Hobby, bool rollback = false)
        {
            try
            {
                try
                {
                    tblHobby row = new tblHobby();
                    row.Id = Guid.NewGuid();
                    row.HobbyName = Hobby.HobbyName;
                    row.Description = Hobby.Description;
                    row.Type = Hobby.Type;
                    row.Image = Hobby.Image;
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
        public int Update(Hobby company, bool rollback = false)
        {
            try
            {
                try
                {
                    return base.Update(new tblHobby
                    {
                        Id = company.Id,
                        HobbyName = company.HobbyName,
                        Description = company.Description,
                        Type = company.Type,
                        Image = company.Image
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
        public List<Hobby> Load()
        {
            try
            {
                List<Hobby> rows = new List<Hobby>();
                base.Load()
                .ForEach(c => rows.Add(
                    new Hobby
                    {
                        Id = c.Id,
                        HobbyName = c.HobbyName,
                        Description = c.Description,
                        Type = c.Type,
                        Image = c.Image
                    }));
                return rows;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Hobby LoadById(Guid id)
        {
            try
            {
                tblHobby row = base.LoadById(id);

                if (row != null)
                {
                    Hobby company = new Hobby
                    {
                        Id = row.Id,
                        HobbyName = row.HobbyName,
                        Description = row.Description,
                        Image = row.Image,
                        Type = row.Type
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

    }
}
