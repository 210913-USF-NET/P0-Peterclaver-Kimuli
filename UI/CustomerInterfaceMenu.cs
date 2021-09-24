using System;
using Models;

namespace UI
{
    public class CustomerInterfaceMenu : IMenu
    {
        private Customer _cust;
        public CustomerInterfaceMenu(){}
        public CustomerInterfaceMenu(Customer cust){
            this._cust = cust;
        }
        public void Start()
        {
            Console.WriteLine($"\nWelcome {_cust.Name}. Please use the menu below to navigate through the App.");

            Console.WriteLine("1. Type 1 to purchase items");
            Console.WriteLine("2. Type 2 to check your previous orders");

            //bool exit = false;

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