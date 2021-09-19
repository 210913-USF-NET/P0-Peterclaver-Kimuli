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
    }
}