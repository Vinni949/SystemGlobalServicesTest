using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace SystemGlobalServicesTest.Models
{
    public class DBTest : DbContext
    {
        public DBTest()
        {
        }
        public DBTest(DbContextOptions<DBTest> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Currency> Currency { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DBTest;Trusted_Connection=True;");

        }


    }
}
