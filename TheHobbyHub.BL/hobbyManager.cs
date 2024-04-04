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
                        Image = hobby.Image
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
                .ForEach(hobby => rows.Add(
                    new Hobby
                    {
                        Id = hobby.Id,
                        HobbyName = hobby.HobbyName,
                        Description = hobby.Description,
                        Type = hobby.Type,
                        Image = hobby.Image
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
                    Hobby hobby = new Hobby
                    {
                        Id = row.Id,
                        HobbyName = row.HobbyName,
                        Description = row.Description,
                        Image = row.Image,
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
