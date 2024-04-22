using Mono.TextTemplating;
using TheHobbyHub.BL.Models;

namespace TheHobbyHub.BL
{
    public class AddressManager : GenericManager<tblAddress>
    {
        public AddressManager(DbContextOptions<HobbyHubEntities> options) : base(options)
        {

        }

        public int Insert(Address address, bool rollback = false)
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
                return base.Delete(id, rollback);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Address> Load()
        {

            try
            {
                List<Address> addresses = new List<Address>();

                using (HobbyHubEntities dc = new HobbyHubEntities(options))
                {
                    addresses = (from a in dc.tblAddresses
                              join ca in dc.tblCompanies on a.Id equals ca.AddressId
                              join ea in dc.tblEvents on a.Id equals ea.AddressId
                              select new Address
                              {
                                  Id = a.Id,
                                  PostalAddress = a.PostalAddress,
                                  City = a.City,
                                  Zip = a.Zip,
                                  State = a.State
                              }
                              )
                              .ToList();
                }
                return addresses;
            }
            catch (Exception)
            {
                throw;
            }



            //try
            //{
            //    List<Address> rows = new List<Address>();
            //    base.Load()
            //    .ForEach(address => rows.Add(
            //        new Address
            //        {
            //            Id = address.Id,
            //            PostalAddress = address.PostalAddress,
            //            City = address.City,
            //            Zip = address.Zip,
            //            State = address.State
            //        }));
            //    return rows;

            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
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
