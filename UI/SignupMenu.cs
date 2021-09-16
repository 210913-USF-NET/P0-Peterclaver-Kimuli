using System;
using Models;
using BL;
using System.Collections.Generic;


namespace UI
{
    public class SignupMenu : IMenu
    {
         private IBL _bl;

        public SignupMenu(IBL bl)
        {
            _bl = bl;
        }

        public void Start() {
            bool exit = false;
            do
            {
                Console.WriteLine("Sign up");
                Console.WriteLine("Type 0 to Sign up.");
                Console.WriteLine("Type 1 to View Customers");
                Console.WriteLine("Type x to go back\n");

                switch (Console.ReadLine())
                {
                    case "0":
                        CreateCustomer();
                        break;
                    case "1":
                        ViewAllCustomers();
                        break;
                    case "x":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Please type the correct input\n");
                        break;
                }
            } while (!exit);
        }

        private void CreateCustomer()
        {
            Console.WriteLine("Please fill in the required information\n");
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Email address: ");
            string email = Console.ReadLine();
            Console.WriteLine("Phone number: ");
            string phonenumber = Console.ReadLine();
            Console.WriteLine("Zipcode: ");
            int zipcode = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Password: ");
            string password = Console.ReadLine();

            Customer newCust = new Customer(name, email, password, phonenumber, zipcode);
            _bl.AddCustomer(newCust);
            Console.WriteLine($"Congratulations! Your account is created: {newCust.ToString()}"); 
        }

        private void ViewAllCustomers()
        {
            List<Customer> allCust = _bl.GetCustomers();

            foreach (Customer cust in allCust)
            {
                Console.WriteLine(cust.ToString());
            }
        }
    }
}