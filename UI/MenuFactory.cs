using DL;
using BL;
using Model = Models;
using DL.Entities;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace UI
{
    public class MenuFactory
    {
        public static IMenu GetMenu (string menuToReturn)
        {
            string connectionString = File.ReadAllText(@"../Connection.txt");
            DbContextOptions<ShoppingAppDBContext> options = new DbContextOptionsBuilder<ShoppingAppDBContext>()
            .UseSqlServer(connectionString).Options;

            ShoppingAppDBContext context = new ShoppingAppDBContext(options);
            
            switch(menuToReturn.ToLower()){
                case "main":
                    return new MainMenu();
                case "login":
                    return new LoginMenu(new CBL(new DBRepo(context)));
                case "signup":
                    return new SignupMenu(new CBL(new DBRepo(context)));
                default:
                    return null;
            }
        }

        public static IMenu GetMenu (string menuToReturn, Model.Customer customer)
        {
            switch(menuToReturn.ToLower()){
                case "customerinterface":
                    return new CustomerInterfaceMenu(customer);
                default:
                    return null;
            }
        }

        public static IMenu GetMenu (string menuToReturn, Model.Manager manager)
        {
            string connectionString = File.ReadAllText(@"../Connection.txt");
            DbContextOptions<ShoppingAppDBContext> options = new DbContextOptionsBuilder
            <ShoppingAppDBContext>().UseSqlServer(connectionString).Options;

            ShoppingAppDBContext context = new ShoppingAppDBContext(options);

            switch(menuToReturn.ToLower()){
                case "managerinterface":
                    return new ManagerInterfaceMenu(new CBL(new DBRepo(context)), manager);
                default:
                    return null;
            }
        }
    }
}