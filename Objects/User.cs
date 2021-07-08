using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using GameClub2.Objects;

namespace GameClub2
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
    }
    public class Admin : User
    {
        public int Salary { get; set; }
    }
    public class Player : User
    {
    }
    class UserContext : DbContext
    {
        public UserContext() : base("GameClub2.Properties.Settings.MyDatabase1ConnectionString")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Player> Players { get; set; }
    }
    class UserFactory
    {
        public static void CreateAdminAndPlayer()
        {
            Admin admin = new Admin { Name = "Petrov I.I.", Adress = "Lenina", Salary = 4500 };
            Player player = new Player { Name = "Ivanov P.P.", Adress = "Pushkina" };
            UserContext userContext = new UserContext();
            userContext.Admins.Add(admin);
            userContext.Players.Add(player);
            userContext.SaveChanges();
            userContext.Dispose();
        }
    }
    static class UserWriter
    {
        public static bool CreateAdminWithValidation(string name,string adress,int salary)
        {
            bool[] results = new bool[] { Validator.Validate(name), Validator.Validate(adress), Validator.Validate(salary) };
            if (results.All(b => b))
            {
                using(UserContext userContext=new UserContext())
                {
                    Admin admin = new Admin() { Name = name, Adress = adress, Salary = salary };
                    userContext.Admins.Add(admin);
                    userContext.SaveChanges();
                }
                return true;
            }
            return false;
        }

        public static bool EditPlayerWithValidation(string newName, string newAdress, Player player)
        {

           bool nameValidationResult = Validator.Validate(newName.Trim(), player.Name);
           bool adressValidationResult = Validator.Validate(newAdress.Trim(), player.Adress);
            if (nameValidationResult || adressValidationResult)
            {
                UserContext UC = new UserContext();
                Player newPlayer = UC.Players.First(p => p.Id == player.Id);
                if (nameValidationResult)
                    newPlayer.Name = newName;
                if (adressValidationResult)
                    newPlayer.Adress = newAdress;

                UC.SaveChanges();
                UC.Dispose();
                return true;
            }
            return false;
        }
        public static bool EditAdminWithValidation(string newName, string newAdress, int newSalary, Admin admin)
        {

           bool nameValidationResult = Validator.Validate(newName.Trim(), admin.Name);
           bool adressValidationResult = Validator.Validate(newAdress.Trim(), admin.Adress);
           bool salaryValidationResult = Validator.Validate(newSalary, admin.Salary);

            if (nameValidationResult||adressValidationResult||salaryValidationResult)
            {
                UserContext UC = new UserContext();
                Admin newAdmin = UC.Admins.First(a => a.Id == admin.Id);
                if (nameValidationResult)
                    newAdmin.Name = newName;
                if (adressValidationResult)
                    newAdmin.Adress = newAdress;
                if (salaryValidationResult)
                    newAdmin.Salary = newSalary;


                UC.SaveChanges();
                UC.Dispose();
                return true;
            }
            return false;
        }
    }
}
