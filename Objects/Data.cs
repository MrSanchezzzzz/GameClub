using System;
using System.Data.Entity;
namespace GameClub2.Objects
{
    class Data
    {
        public int Id { get; set; }
        public int CompId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime RentEndDate { get; set; }
        public string TransactionCode { get; set; }
        public int PlayerId { get; set; }
        public int AdminId { get; set; }
        public int Price { get; set; }
    }
    class DataContext : DbContext
    {
        public DataContext() : base("GameClub2.Properties.Settings.MyDatabase1ConnectionString")
        {

        }
        public DbSet<Data> Datas { get; set; }
    }
    class DataFactory
    {
        public static void CreateBaseData()
        {
            DataContext dataContext = new DataContext();
            dataContext.Datas.Add(new Data { CompId=1, AdminId=1, PlayerId=2, RentDate=DateTime.Parse("05.05.2021 9:00"), RentEndDate= DateTime.Parse("05.05.2021 12:00"), TransactionCode="abcd", Price=250 });
            dataContext.SaveChanges();
        }
        public static void CreateBaseDataWithOthers()
        {
            CreateBaseData();
            UserFactory.CreateAdminAndPlayer();
            DeviceFactory.CreateBaseDevices();
            ComputerFactory.CreateBaseComputer();
        }
    }
}
