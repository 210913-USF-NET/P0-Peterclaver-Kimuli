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
                    CreateStore();
                    break;
                default:
                    Console.WriteLine("Please type the correct input");
                    break;
            }
        }

        private void CreateStore(){
            Console.WriteLine("\nCreate a new Store.");
            
            //Capturing store number
            Store newStore = new Store();
            number:
            Console.WriteLine("Store number:");
            string storeNumber = Console.ReadLine();
            try{
                newStore.Number = storeNumber;
            }
            catch(InputInvalidException e){
                Console.WriteLine(e.Message);
                goto number;
            }

            //Capturing store location
            location:
            Console.WriteLine("Store Location:");
            string storeLocation = Console.ReadLine();
            try{
                newStore.Location = storeLocation;
            }
            catch(InputInvalidException e){
                Console.WriteLine(e.Message);
                goto location;
            }

            //Capturing store zipcode
            zip:
            Console.WriteLine("Store Zipcode:");
            string storeZip = Console.ReadLine();
            try{
                newStore.Zipcode = storeZip;
            }
            catch(InputInvalidException e){
                Console.WriteLine(e.Message);
                goto zip;
            }

            Console.WriteLine($"You have successfully created {newStore.ToString()}");
        }
    }
}