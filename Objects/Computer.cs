using System.Data.Entity;

namespace GameClub2.Objects
{
    class Computer
    {
        public int Id { get; set; }
        public int ProcessorId { get; set; }
        public int MonitorId { get; set; }
        public int GPUId { get; set; }
        public int HDDId { get; set; }
    }
    class ComputerContext : DbContext
    {
        public ComputerContext() : base("GameClub2.Properties.Settings.MyDatabase1ConnectionString")
        {

        }
        public DbSet<Computer> Computers { get; set; }
    }
    class ComputerFactory
    {
        public static void CreateBaseComputer()
        {
            ComputerContext computerContext = new ComputerContext();
            computerContext.Computers.Add(new Computer { ProcessorId = 1, GPUId = 2, HDDId = 3, MonitorId = 4 });
            computerContext.SaveChanges();
            computerContext.Dispose();
        }
    }
}
