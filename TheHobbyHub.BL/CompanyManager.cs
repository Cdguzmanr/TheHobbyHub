using Azure.Identity;
using Mono.TextTemplating;
using System.Threading.Tasks.Dataflow;
using TheHobbyHub.BL.Models;
using TheHobbyHub.PL.Entities;

namespace TheHobbyHub.BL
{
    public class CompanyManager : GenericManager<tblCompany>
    {
        public CompanyManager(DbContextOptions<HobbyHubEntities> options) : base(options)
        {

        }

        public int Insert(Company company, bool rollback = false)
        {
            try
            {
                tblCompany row = new tblCompany();
                row.Id = Guid.NewGuid();
                row.CompanyName = company.CompanyName;
                row.AddressId = company.AddressId;
                

                return base.Insert(row, rollback);
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
                return base.Update(new tblCompany
                {
                    Id = company.Id,
                    CompanyName = company.CompanyName,
                    AddressId = company.AddressId,

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
                int results = 0;
                
                using (HobbyHubEntities dc = new HobbyHubEntities(options))
                {
                    IDbContextTransaction transaction = null;
                    if(rollback) transaction = dc.Database.BeginTransaction();

                    tblCompany deleteRow = dc.tblCompanies.FirstOrDefault(x => x.Id == id);

                    if (deleteRow != null)
                    {
                        //delete all the associated tblEvent Rows
                        var Events = dc.tblEvents.Where(i => i.CompanyId == id);
                        dc.tblEvents.RemoveRange(Events);

                        //delete all the associated tblFriend Rows
                        var Friends = dc.tblFriends.Where(f => f.CompanyId == id);
                        dc.tblFriends.RemoveRange(Friends);

                        //Remove the company
                        dc.tblCompanies.Remove(deleteRow);

                        results = dc.SaveChanges();

                        if (rollback) transaction.Rollback();
                    }
                    else
                    {
                        throw new Exception("Row not Found");
                    }
                    return results;
                }
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
                List<Company> companies = new List<Company>();

                using (HobbyHubEntities dc = new HobbyHubEntities(options))
                {
                    companies = (from c in dc.tblCompanies
                              join ca in dc.tblAddresses on c.AddressId equals ca.Id
                              join u in dc.tblUsers on c.UserId equals u.Id
                              select new Company
                              {
                                  Id = c.Id,
                                  CompanyName = c.CompanyName,
                                  CompanyPostalAddress = ca.PostalAddress,
                                  CompanyCity = ca.City,
                                  CompanyState = ca.State,
                                  CompanyZip = ca.Zip,
                                  AddressId = c.AddressId,
                                  ImagePath = u.Image, 
                              }
                              )
                              .ToList();
                }
                return companies;
            }
            catch (Exception)
            {
                throw;
            }


            //try
            //{
            //    List<Company> rows = new List<Company>();
            //    base.Load()
            //    .ForEach(company => rows.Add(
            //        new Company
            //        {
            //            Id = company.Id,
            //            CompanyName = company.CompanyName,
            //            UserName = company.UserName,
            //            Password = company.Password,
            //            Image = company.Image,
            //            AddressId = company.AddressId,
            //        }));
            //    return rows;

            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }
        public Company LoadById(Guid id)
        {
            try
            {
                using (HobbyHubEntities dc = new HobbyHubEntities(options))
                {
                    tblCompany row = dc.tblCompanies.FirstOrDefault(c => c.Id == id);

                    if (row != null)
                    {
                        Company company = new Company
                        {
                            Id = row.Id,
                            CompanyName = row.CompanyName,
                            AddressId = row.AddressId,
                            CompanyPostalAddress = new AddressManager(options).LoadById(row.AddressId).PostalAddress,
                            CompanyCity = new AddressManager(options).LoadById(row.AddressId).PostalAddress,
                            CompanyState = new AddressManager(options).LoadById(row.AddressId).PostalAddress,
                            CompanyZip = new AddressManager(options).LoadById(row.AddressId).PostalAddress,
                        };
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

        public List<Company> LoadByAddressId(Guid? addressId = null)
        {
            try
            {
                List<Company> compnaies = new List<Company>();

                using (HobbyHubEntities dc = new HobbyHubEntities(options))
                {
                    var results = (from cm in dc.tblCompanies
                                   join ac in dc.tblAddresses on cm.AddressId equals ac.Id
                                   where cm.AddressId == addressId
                                   select new
                                   {
                                       Id = cm.Id,
                                       CompanyName = cm.CompanyName,
                                       AddressId = cm.AddressId
                                   }).ToList();

                    results.ForEach(r => compnaies.Add(
                         new Company
                         {
                             Id = r.Id,
                             CompanyName = r.CompanyName,
                             AddressId = r.AddressId
                         }
                        ));

                    return compnaies;
                }

                return compnaies;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string GetHash(string Password)
        {
            using (var hasher = new System.Security.Cryptography.SHA1Managed())
            {
                var hashbytes = System.Text.Encoding.UTF8.GetBytes(Password);
                return Convert.ToBase64String(hasher.ComputeHash(hashbytes));
            }
        }

    }
}
