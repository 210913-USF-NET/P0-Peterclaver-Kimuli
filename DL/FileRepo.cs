using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using Models;
using System.Collections.Generic;


namespace DL
{
    public class FileRepo : IRepo
    {
        private const string filePath = "../DL/Customers.json";

        private string jsonString;

        public Customer AddCustomer(Customer cust){
            List<Customer> allCust = GetCustomers();

            allCust.Add(cust);

            jsonString = JsonSerializer.Serialize(allCust);

            File.WriteAllText(filePath, jsonString);

            return cust;
        }

        public List<Customer> GetCustomers(){
            jsonString = File.ReadAllText(filePath);

            return JsonSerializer.Deserialize<List<Customer>>(jsonString);
        }

        public Customer LoginCustomer(string phonenumber, string password)
        {
            Customer loggedCustomer = new Customer();
            List <Customer> allCustomers = GetCustomers();
            
            for(int i = 0; i<allCustomers.Count; i++)
            {
                if(allCustomers[i].Phonenumber == phonenumber && allCustomers[i].Password == password)
                {
                    loggedCustomer = allCustomers[i];
                }
            }

            return loggedCustomer;
        }
    }
}