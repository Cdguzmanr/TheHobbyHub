using Azure.Identity;
using Mono.TextTemplating;
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
                row.UserId = company.UserId;
                row.Description = company.Description;
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
                    UserId = company.UserId,
                    Description = company.Description,
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
                .ForEach(company => rows.Add(
                    new Company
                    {
                        Id = company.Id,
                        CompanyName = company.CompanyName,
                        UserId = company.UserId,
                        Description = company.Description,
                        AddressId = company.AddressId,
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
                        UserId = row.UserId,
                        Description = row.Description,
                        AddressId = row.AddressId,
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


        public List<Company> LoadByUserId(Guid? userId = null)
        {
            try
            {
                List<Company> compnaies = new List<Company>();

                using (HobbyHubEntities dc = new HobbyHubEntities(options))
                {
                    var results = (from cm in dc.tblCompanies
                                   join cu in dc.tblUsers on cm.UserId equals cu.Id
                                   join ac in dc.tblAddresses on cm.AddressId equals ac.Id
                                   where cm.UserId == userId
                                   select new Company
                                   {
                                       Id = cm.Id,
                                       CompanyName = cm.CompanyName,
                                       UserId = cm.UserId,
                                       Description = cm.Description,
                                       AddressId = cm.AddressId
                                   }).ToList();

                    results.ForEach(r => compnaies.Add(
                         new Company
                         {
                             Id = r.Id,
                             CompanyName = r.CompanyName,
                             UserId = r.UserId,
                             Description = r.Description,
                             AddressId = r.AddressId
                         }
                        ));

                    return compnaies;
                }
            }
            catch (Exception)
            {
                throw;
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
                                   join cu in dc.tblUsers on cm.UserId equals cu.Id
                                   join ac in dc.tblAddresses on cm.AddressId equals ac.Id
                                   where cm.AddressId == addressId
                                   select new Company
                                   {
                                       Id = cm.Id,
                                       CompanyName = cm.CompanyName,
                                       UserId = cm.UserId,
                                       Description = cm.Description,
                                       AddressId = cm.AddressId
                                   }).ToList();

                    results.ForEach(r => compnaies.Add(
                         new Company
                         {
                             Id = r.Id,
                             CompanyName = r.CompanyName,
                             UserId = r.UserId,
                             Description = r.Description,
                             AddressId = r.AddressId
                         }
                        ));

                    return compnaies;
                }
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
