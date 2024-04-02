
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System.IO;
using TheHobbyHub.PL.Data;

namespace TheHobbyHub.BL.Test
{
    [TestClass]
    public abstract class utBase
    {
        protected  HobbyHubEntities dc;
        protected IDbContextTransaction transaction;
        private IConfigurationRoot _configuration;


        // represent the database configuration
        protected DbContextOptions<HobbyHubEntities> options;

        public utBase()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            _configuration = builder.Build();

            options = new DbContextOptionsBuilder<HobbyHubEntities>()
                .UseSqlServer(_configuration.GetConnectionString("DatabaseConnection"))
                .UseLazyLoadingProxies()
                .Options;

            dc = new HobbyHubEntities(options);
        }

        [TestInitialize]
        public void TestInitialize()
        {
            transaction = dc.Database.BeginTransaction();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            transaction.Rollback();
            transaction.Dispose();
            dc = null;
        }

        //public List<T> LoadTest()
        //{
        //    return dc.Set<T>().ToList();
        //}

        //public int InsertTest(T row)
        //{
        //    dc.Set<T>().Add(row);
        //    return dc.SaveChanges();
        //}

        //public int UpdateTest(T row)
        //{

        //    dc.Entry(row).State = EntityState.Modified;
        //    return dc.SaveChanges();
        //}

        //public int DeleteTest(T row)
        //{
        //    dc.Set<T>().Remove(row);
        //    return dc.SaveChanges();
        //}

    }
}
