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
                try
                {
                    tblAddress row = new tblAddress();
                    row.Id = Guid.NewGuid();
                    row.Address = address.PostalAddress;
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
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Update(Address address, bool rollback = false)
        {
            try
            {
                try
                {
                    return base.Update(new tblAddress
                    {
                        Id = address.Id,
                        Address = address.PostalAddress,
                        City = address.City,
                        State = address.State,
                        Zip = address.Zip

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
        public List<Address> Load()
        {
            try
            {
                List<Address> rows = new List<Address>();
                base.Load()
                .ForEach(c => rows.Add(
                    new Address
                    {
                        Id = c.Id,
                        PostalAddress = c.Address,
                        City = c.City,
                        State = c.State,
                        Zip = c.Zip
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
                    Address Address = new Address
                    {
                        Id = row.Id,
                        PostalAddress = row.Address,
                        City = row.City,
                        State = row.State,
                        Zip = row.Zip
                    };
                    return Address;
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
