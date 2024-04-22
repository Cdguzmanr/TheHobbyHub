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

        public Guid Insert(Company company, bool rollback = false)
        {
            try
            {
                tblCompany row = new tblCompany();
                row.Id = Guid.NewGuid();
                row.CompanyName = company.CompanyName;
                row.UserName = company.UserName;
                row.Password = company.Password;
                row.Image = company.Image;
                row.AddressId = company.AddressId;
                row.User.Image = company.Image;

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
                    UserName = company.UserName,
                    Password = company.Password,
                    Image = company.Image,
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
                        UserName = company.UserName,
                        Password = company.Password,
                        Image = company.Image,
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
                        UserName = row.UserName,
                        Password = row.Password,
                        Image = row.Image,
                        AddressId = row.AddressId,
                        Image = row.User.Image,
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
                                       UserName = cm.UserName,
                                       Password = cm.Password,
                                       Image = cm.Image,
                                       AddressId = cm.AddressId
                                   }).ToList();

                    results.ForEach(r => compnaies.Add(
                         new Company
                         {
                             Id = r.Id,
                             CompanyName = r.CompanyName,
                             UserName = r.UserName,
                             Password = r.Password,
                             Image = r.Image,
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
