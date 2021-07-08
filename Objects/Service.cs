using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace GameClub2.Objects
{
    class Service
    {
        public int Id { get; set; }
        public string TransactionCode { get; set; }
        public int Tariff { get; set; }
    }
    class ServiceContext : DbContext
    {
        public ServiceContext() : base("GameClub2.Properties.Settings.MyDatabase1ConnectionString")
        {

        }
        public DbSet<Service> Services { get; set; }
    }
}
