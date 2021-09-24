using System;
using Models;
using BL;
using System.Collections.Generic;
using Serilog;

namespace UI
{
    public class StoreManagerInterface : IMenu
    {
        private CBL _bl;
        private Store _store;

        public StoreManagerInterface(CBL bl, Store store)
        {
            _bl = bl;
            _store = store;
        }
        public void Start()
        {
            Console.WriteLine($"        Store: {_store.Number}");
            
            bool exit = false;

            do
            {
                Console.WriteLine("Navigate the store using menu below;");
                Console.WriteLine("1. Type 0 to view Products.");
                Console.WriteLine("2. Type 1 to add Products.");
                Console.WriteLine("3. Type 2 to view orders.");
                Console.WriteLine("4. Type 3 to search for a customer.");
                Console.WriteLine("5. Type x to exit.");

                switch(Console.ReadLine())
                {
                    case "0":
                        Console.WriteLine("0");
                        break;
                    case "1":
                        Console.WriteLine("1");
                        break;
                    case "2":
                        Console.WriteLine("2");
                        break;
                    case "3":
                        Console.WriteLine("3");
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
    }
}