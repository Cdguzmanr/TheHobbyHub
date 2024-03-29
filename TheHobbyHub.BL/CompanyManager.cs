using System.IO;
using TheHobbyHub.BL.Models;

namespace TheHobbyHub.BL
{
    public class CompanyManager
    {
        public CompanyManager(DbContextOptions<HobbyHubEntities> options)
        {
            
        }
   

        

        public static int Insert(Company company, bool rollback = false) // Id by reference
        {
            try
            {
                int results = 0;
                using (HobbyHubEntities dc = new HobbyHubEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();



                    // Create a new row and fill in the data
                    tblCompany row = new tblCompany();
                    row.Id = Guid.NewGuid();
                    row.CompanyName = company.CompanyName;
                    row.UserName = company.UserName;
                    row.Password = company.Password;
                    row.Image = company.Image;
                    row.AddressId = company.AddressId;
                    

                    // IMPORTANT - BACK FILL THE ID 
                    company.Id = row.Id;

                    // Add the row
                    dc.tblCompanies.Add(row);
                    results = dc.SaveChanges();

                    if (rollback) transaction.Rollback();
                }
                return results;
            }
            catch (Exception) { throw; }
        }

        public static int Update(Company company, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (HobbyHubEntities dc = new HobbyHubEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    // Get the row that we are trying to update
                    tblCompany entity = dc.tblCompanies.FirstOrDefault(s => s.Id == company.Id);
                    if (entity != null)
                    {
                        entity.CompanyName = company.CompanyName;
                        entity.UserName = company.UserName;
                        entity.Password = company.Password;
                        entity.Image = company.Image;
                        entity.AddressId = company.AddressId;

                        results = dc.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Row does not exist");
                    }

                    if (rollback) transaction.Rollback();
                }

                return results;
            }
            catch (Exception) { throw; }
        }

        public static Company LoadById(Guid id)
        {
            try
            {
                using (HobbyHubEntities dc = new HobbyHubEntities())
                {
                    tblCompany entity = dc.tblCompanies.FirstOrDefault(s => s.Id == id);
                    if (entity != null)
                    {
                        return new Company
                        {
                            Id = entity.Id,
                            CompanyName = entity.CompanyName,
                            UserName = entity.UserName,
                            Password = entity.Password,
                            Image = entity.Image,
                            AddressId = entity.AddressId,
                    };
                    }
                    else { throw new Exception(); }
                }
            }
            catch (Exception) { throw; }
        }

        public static List<Company> Load()
        {
            try
            {
                List<Company> list = new List<Company>();
                using (HobbyHubEntities dc = new HobbyHubEntities())
                {
                    // Load the rows from the database and add them to the list
                    dc.tblCompanies
                        .ToList()
                        .ForEach(company => list.Add(new Company
                        {
                            Id = company.Id,
                            CompanyName = company.CompanyName,
                            UserName = company.UserName,
                            Password = company.Password,
                            Image = company.Image,
                            AddressId = company.AddressId,
                        }));

                }
                return list;
            }
            catch (Exception) { throw; }
        }

        public static int Delete(Guid id, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (HobbyHubEntities dc = new())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    // Get the row that we are trying to update
                    tblCompany entity = dc.tblCompanies.FirstOrDefault(s => s.Id == id);
                    if (entity != null)
                    {
                        dc.tblCompanies.Remove(entity);

                        results = dc.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Row does not exist");
                    }
                    if (rollback) transaction.Rollback();
                }
                return results;
            }
            catch (Exception) { throw; }
        }
    }
}









    // -------------------------- Static class - no need to instantiate --------------------------------------------------------
    /**
    public class CompanyManager : GenericManager<tblCompany>
    {
        public CompanyManager(DbContextOptions<HobbyHubEntities> options) : base(options)
        {

        }

        public int Insert(Company Company, bool rollback = false)
        {
            try
            {
                try
                {
                    tblCompany row = new tblCompany();
                    row.Id = Guid.NewGuid();
                    row.CompanyName = Company.CompanyName;
                    row.UserName = Company.UserName;
                    row.Password = Company.Password;
                    row.Image = Company.Image;
                    row.AddressId = Company.AddressId;
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
        public int Update(Company company, bool rollback = false)
        {
            try
            {
                try
                {
                    return base.Update(new tblCompany
                    {
                        Id = company.Id,
                        CompanyName = company.CompanyName,
                        UserName = company.UserName,
                        Password = company.Password,
                        Image = company.Image,
                        AddressId = company.AddressId
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
        public List<Company> Load()
        {
            try
            {
                List<Company> rows = new List<Company>();
                base.Load()
                .ForEach(c => rows.Add(
                    new Company
                    {
                        Id = c.Id,
                        CompanyName = c.CompanyName,
                        UserName = c.UserName,
                        Password = c.Password,
                        Image  = c.Image,
                        AddressId = c.AddressId
                    }));
                return rows;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Company LoadById(Guid id)
        {
            try
            {
                tblCompany row = base.LoadById(id);

                if (row != null)
                {
                    Company company = new Company
                    {
                        Id = row.Id,
                        CompanyName = row.CompanyName,
                        UserName = row.Password,
                        Image = row.Image,
                        AddressId = row.AddressId
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

        public Company LoadByAddressId(Guid addressId)
        {
            try
            {
                using (HobbyHubEntities dc = new HobbyHubEntities(options))
                {

                    var row = (from c in dc.tblCompanies
                               where c.AddressId == addressId
                               orderby c.Id descending
                               select c).FirstOrDefault();

                    var company = new Company();
                    if (row != null)
                    {
                        company.Id = row.Id;
                        company.CompanyName = row.CompanyName;
                        company.UserName = row.UserName;
                        company.Password = row.Password;
                        company.Image = row.Image;
                        company.AddressId = row.AddressId;

                        return company;
                    }
                    else
                    {
                        throw new Exception("Row was not found.");
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
    /**/

