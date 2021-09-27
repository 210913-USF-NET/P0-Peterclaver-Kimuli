using System;
using Models;
using BL;
using System.Collections.Generic;
using Serilog;
using System.Text.RegularExpressions;

namespace UI
{
    public class StoreCustomerInterface : IMenu
    {
        private CBL _bl;
        private Store _store;
        public StoreCustomerInterface(CBL bl, Store store)
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
                Console.WriteLine("1. Type 1 to place an order.");
                Console.WriteLine("2. Type x to exit.");

                switch(Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("1");
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