using System;
using Models;

namespace UI
{
    public class ManagerInterfaceMenu : IMenu
    {
        private Manager _manager;
        public ManagerInterfaceMenu(){}
        public ManagerInterfaceMenu(Manager manager){
            this._manager = manager;
        }
        public void Start()
        {
            Console.WriteLine($"\nWelcome {_manager.Name}. Please use the menu below to navigate through the App.");

            Console.WriteLine("1. Type 1 to select a store location");
            Console.WriteLine("2. Type 2 to create a new location");

            bool exit = false;

            switch(Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("1");
                    break;
                case "2":
                    Console.WriteLine("2");
                    break;
                default:
                    Console.WriteLine("Please type the correct input");
                    break;
            }
        }
    }
}