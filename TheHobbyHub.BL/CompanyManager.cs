using Castle.Core.Resource;
using Microsoft.EntityFrameworkCore;
using TheHobbyHub.BL.Models;
using TheHobbyHub.HobbyHub.BL;
using TheHobbyHub.PL.Data;
using TheHobbyHub.PL.Entities;

namespace ARC.DVDCentral.BL
{
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
