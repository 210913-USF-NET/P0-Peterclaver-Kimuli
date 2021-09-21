using DL;
using BL;
using Models;

namespace UI
{
    public class MenuFactory
    {
        public static IMenu GetMenu (string menuToReturn)
        {
            switch(menuToReturn.ToLower()){
                case "main":
                    return new MainMenu();
                case "login":
                    return new LoginMenu(new CBL(new FileRepo()));
                case "signup":
                    return new SignupMenu(new CBL(new FileRepo()));
                default:
                    return null;
            }
        }

        public static IMenu GetMenu (string menuToReturn, Customer customer)
        {
            switch(menuToReturn.ToLower()){
                case "customerinterface":
                    return new CustomerInterfaceMenu(customer);
                default:
                    return null;
            }
        }

        public static IMenu GetMenu (string menuToReturn, Manager manager)
        {
            switch(menuToReturn.ToLower()){
                case "managerinterface":
                    return new ManagerInterfaceMenu(manager);
                default:
                    return null;
            }
        }
    }
}