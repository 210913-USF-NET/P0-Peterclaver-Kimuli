using System;
using Models;
using BL;
using System.Collections.Generic;
using Serilog;
using System.Text.RegularExpressions;

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
                        AddProduct();
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

        private void AddProduct()
        {
            Console.WriteLine("\nCreate a product...");

            Product newProduct = new Product();
            name:
            Console.WriteLine("Product name: ");
            try{
                newProduct.Name = Console.ReadLine();
            }
            catch(InputInvalidException e){
                Console.WriteLine(e.Message);
                goto name;
            }
            
            quantity:
            Console.WriteLine("On-hand quantity: ");
            string quantity = Console.ReadLine();
            int parsedInt;
            bool parseSuccess = Int32.TryParse(quantity, out parsedInt);
            if(parseSuccess)
            {
                try
                {
                    newProduct.Quantity = parsedInt;
                }
                catch(InputInvalidException e)
                {
                    Console.WriteLine(e.Message);
                    goto quantity;
                }
            }
            else{
                System.Console.WriteLine("Please put the correct quantity.");
                goto quantity;
            }

            unitprice:
            Console.WriteLine("Unit price: ");
            string unitPrice = Console.ReadLine();
            decimal parsedDecimal;
            try 
            {
                parsedDecimal = System.Convert.ToDecimal(unitPrice);
                Console.WriteLine($"Unit is : {parsedDecimal}");
            }
            catch (System.OverflowException)
            {
                System.Console.WriteLine(
                    "Please put a correct price.");
                goto unitprice;
            }
            catch (System.FormatException)
            {
                System.Console.WriteLine(
                    "The unit price should be a decimal number.");
                goto unitprice;
            }
            catch (System.ArgumentNullException) 
            {
                System.Console.WriteLine(
                    "Please fill in the unit price.");
                goto unitprice;
            }
        }
    }
}