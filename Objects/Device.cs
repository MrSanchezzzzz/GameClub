using System;
using System.Data.Entity;
namespace GameClub2.Objects
{
    class Device
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Creator { get; set; }
        public string Vendor { get; set; }
        public int Price { get; set; } 
    }
    class DeviceContext : DbContext
    {
        public DeviceContext():base("GameClub2.Properties.Settings.MyDatabase1ConnectionString")
        {

        }
        public DbSet<Device> Devices { get; set; }
    }
    class DeviceFactory
    {
        public static void CreateBaseDevices()
        {
            Device[] devices = new Device[]
            {
                new Device { Model = "I5-9100F", Creator = "Intel", Vendor = "Rozetka", Price = 7000 },
                new Device { Model = "RX580", Creator = "AMD", Vendor = "Rozetka", Price = 4000 },
                new Device { Model = "Burst 120GB", Creator = "Patriot", Vendor = "Diavest", Price = 2500 },
                new Device { Model = "243V5QHABA/01", Creator = "Phillips", Vendor = "ALLO", Price = 700 }
            };
            DeviceContext dc = new DeviceContext();
            dc.Devices.AddRange(devices);
            dc.SaveChanges();
            dc.Dispose();
        }
    }
}
