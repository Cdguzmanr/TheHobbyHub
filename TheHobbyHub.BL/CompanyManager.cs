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
                row.UserName = company.UserName;
                row.Password = company.Password;
                row.Image = company.Image;
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
