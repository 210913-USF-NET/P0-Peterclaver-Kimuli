using System;
using Models;
using DL;
using BL;
using System.Collections.Generic;
using Serilog;

namespace UI
{
    public class LoginMenu : IMenu
    {
        private IBL _bl;

        public LoginMenu(IBL bl){
            _bl = bl;
        }
        
        public void Start()
        {
            Log.Information("\nLogging in...");
            Console.WriteLine("Login Please!");

            login:
            Console.WriteLine("Phonenumber: "); 
            string phonenumber = Console.ReadLine();

            Console.WriteLine("Password: "); 
            string password = Console.ReadLine();

            Customer loggedCustomer = new Customer();

            List<Customer> allCustomers =_bl.GetCustomers();

            Manager loggedManager = new Manager();

            List<Manager> allManagers =_bl.GetManagers();

            bool tracker = true;
            while(tracker){
                for(int i = 0; i < allCustomers.Count; i++)
                {
                    if(allCustomers[i].Phonenumber == phonenumber && allCustomers[i].Password == password)
                    {
                        loggedCustomer = allCustomers[i];
                        tracker = false;
                    }
                    tracker = false;
                }
            }            

            if(loggedCustomer.Phonenumber != phonenumber || loggedCustomer.Password != password)
            {
                tracker = true;
                while(tracker)
                {
                    for(int i = 0; i < allManagers.Count; i++)
                    {
                        if(allManagers[i].Phonenumber == phonenumber && allManagers[i].Password == password)
                        {
                            loggedManager = allManagers[i];
                            tracker = false;
                        }
                        tracker = false;
                    }
                }
                
                if(loggedManager.Phonenumber != phonenumber || loggedManager.Password != password)
                {
                    Log.Information("\nFailed login attempt!");
                    Console.WriteLine("The information does not match our records! Please try again.");
                    goto login;
                }
                else{
                    Log.Information("\nSuccessfully Logged in!");
                    MenuFactory.GetMenu("managerinterface", loggedManager).Start();
                }
                
            }
            else{
                Log.Information("\nSuccessfully Logged in!");
                MenuFactory.GetMenu("customerinterface", loggedCustomer).Start();
            }
        }
    }
}