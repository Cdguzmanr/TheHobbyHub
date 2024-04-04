using Mono.TextTemplating;
using TheHobbyHub.BL.Models;

namespace TheHobbyHub.BL
{
    public class AddressManager : GenericManager<tblAddress>
    {
        public AddressManager(DbContextOptions<HobbyHubEntities> options) : base(options)
        {

        }

        public Guid Insert(Address address, bool rollback = false)
        {
            try
            {
                tblAddress row = new tblAddress();
                row.Id = Guid.NewGuid();
                row.PostalAddress = address.PostalAddress;
                row.City = address.City;
                row.Zip = address.Zip;
                row.State = address.State;

                return base.Insert(row, rollback);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Update(Address address, bool rollback = false)
        {
            try
            {
                int results = base.Update(new tblAddress
                {
                    Id = address.Id,
                    PostalAddress = address.PostalAddress,
                    City = address.City,
                    Zip = address.Zip,
                    State = address.State
                }, rollback);
                return results;
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
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblAddress deleteRow = dc.tblAddresses.FirstOrDefault(f => f.Id == id);

                    if (deleteRow != null)
                    {
                        // delete all the associated tblMovieGenre rows. 
                        var companies = dc.tblCompanies.Where(g => g.AddressId == id);
                        dc.tblCompanies.RemoveRange(companies);


                        var events = dc.tblEvents.Where(g => g.AddressId == id);
                        dc.tblEvents.RemoveRange(events);
                        // remove the movie
                        dc.tblAddresses.Remove(deleteRow);

                        // Commit the changes and get the number of rows affected
                        results = dc.SaveChanges();

                        if (rollback) transaction.Rollback();
                    }
                    else
                    {
                        throw new Exception("Row was not found.");
                    }
                }
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Address> Load()
        {
            try
            {
                List<Address> rows = new List<Address>();
                base.Load()
                .ForEach(address => rows.Add(
                    new Address
                    {
                        Id = address.Id,
                        PostalAddress = address.PostalAddress,
                        City = address.City,
                        Zip = address.Zip,
                        State = address.State
                    }));
                return rows;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Address LoadById(Guid id)
        {
            try
            {
                tblAddress row = base.LoadById(id);

                if (row != null)
                {
                    Address address = new Address
                    {
                        Id = row.Id,
                        PostalAddress = row.PostalAddress,
                        City = row.City,
                        Zip = row.Zip,
                        State = row.State
                    };
                    return address;
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
