using System;
using Models;

namespace UI
{
    public class CustomerInterfaceMenu : IMenu
    {
        private Customer _cust;
        public CustomerInterfaceMenu(){}
        public CustomerInterfaceMenu(Customer cust){
            _cust = cust;
        }
        public void Start()
        {
           Console.WriteLine($"\nWelcome {_cust.Name}");

           bool exit = false;

           switch(Console.ReadLine())
            {
                case "0":
                    Console.WriteLine("Hey there");
                    break;
                case "1":
                    Console.WriteLine("Thank you");
                    break;
            }
        }
    }
}