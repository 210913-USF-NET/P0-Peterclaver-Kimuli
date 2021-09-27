using System;
using System.Collections.Generic;
using Models;
using BL;
using Serilog;

namespace UI
{
    public class CustomerInterfaceMenu : IMenu
    {
        private CBL _bl; 
        private Customer _cust;
        public CustomerInterfaceMenu(){}
        public CustomerInterfaceMenu(CBL bl, Customer cust){
            _bl = bl;
            this._cust = cust;
        }
        public void Start()
        {
            Console.WriteLine($"\nWelcome {_cust.Name}. Please use the menu below to navigate through the App.");

            bool exit = false;

            do{
                Console.WriteLine("1. Type 1 to select a store");
                Console.WriteLine("2. Type 2 to check your previous orders... type x to exit!");

                switch(Console.ReadLine())
                {
                    case "1":
                        SelectStore();
                        break;
                    case "2":
                        Console.WriteLine("2");
                        break;
                    case "x":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Please type the correct input");
                        break;
                }
            }while(!exit);
            
        }

        private void SelectStore()
        {
            menu:
            List<Store> storesToSelect = _bl.GetCustomerStores();
            Console.WriteLine("\nPlease select from the stores below:");
            if(storesToSelect.Count == 0 || storesToSelect == null)
            {
                Console.WriteLine("There are no stores currently\n");
                return;
            }
            for(int i=0; i<storesToSelect.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {storesToSelect[i].Number}, {storesToSelect[i].Location} {storesToSelect[i].Zipcode}");
            }

            string input = Console.ReadLine();
            int parsedInput;
            bool parseSuccess = Int32.TryParse(input, out parsedInput);
            if (parseSuccess && parsedInput >= 0 && parsedInput <= storesToSelect.Count)
            {
                int actualInput = parsedInput - 1;
                Log.Information("Logging into the store customer menu");
                MenuFactory.GetMenu("storecustomermenu", storesToSelect[actualInput]).Start();
            }
            else
            {
                Console.WriteLine("Invalid input.");
                goto menu;
            }
        }
    }
}