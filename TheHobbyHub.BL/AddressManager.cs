using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TheHobbyHub.BL
{
    public static class AddressManager
    {
        public static int Insert(Address address, DbContextOptions<HobbyHubEntities> options, bool rollback = false)
        {
            try
            {
                using (var dbContext = new HobbyHubEntities(options))
                {
                    tblAddress row = new tblAddress
                    {
                        Id = Guid.NewGuid(),
                        Address = address.PostalAddress,
                        City = address.City,
                        Zip = address.Zip,
                        State = address.State
                    };
                    dbContext.Set<tblAddress>().Add(row);
                    return dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int Update(Address address, DbContextOptions<HobbyHubEntities> options, bool rollback = false)
        {
            try
            {
                using (var dbContext = new HobbyHubEntities(options))
                {
                    var existingRow = dbContext.Set<tblAddress>().Find(address.Id);
                    if (existingRow != null)
                    {
                        existingRow.Address = address.PostalAddress;
                        existingRow.City = address.City;
                        existingRow.Zip = address.Zip;
                        existingRow.State = address.State;
                        return dbContext.SaveChanges();
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

        public static int Delete(Guid id, DbContextOptions<HobbyHubEntities> options, bool rollback = false)
        {
            try
            {
                using (var dbContext = new HobbyHubEntities(options))
                {
                    var row = dbContext.Set<tblAddress>().Find(id);
                    if (row != null)
                    {
                        dbContext.Set<tblAddress>().Remove(row);
                        return dbContext.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Row does not exist.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Address> Load(DbContextOptions<HobbyHubEntities> options)
        {
            try
            {
                using (var dbContext = new HobbyHubEntities(options))
                {
                    return dbContext.Set<tblAddress>()
                        .Select(c => new Address
                        {
                            Id = c.Id,
                            PostalAddress = c.Address,
                            City = c.City,
                            State = c.State,
                            Zip = c.Zip
                        })
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Address LoadById(Guid id, DbContextOptions<HobbyHubEntities> options)
        {
            try
            {
                using (var dbContext = new HobbyHubEntities(options))
                {
                    var row = dbContext.Set<tblAddress>().Find(id);
                    if (row != null)
                    {
                        return new Address
                        {
                            Id = row.Id,
                            PostalAddress = row.Address,
                            City = row.City,
                            State = row.State,
                            Zip = row.Zip
                        };
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
