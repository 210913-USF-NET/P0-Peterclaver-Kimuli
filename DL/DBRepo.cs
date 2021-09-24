using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model = Models;
using Entity = DL.Entities;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DL
{
    public class DBRepo : IRepo
    {
        private Entity.ShoppingAppDBContext _context;
        public DBRepo(Entity.ShoppingAppDBContext context)
        {
            _context = context;
        }

        //This method adds a new customer to the DB
        public Model.Customer AddCustomer(Model.Customer cust){
            Entity.Customer custToAdd = new Entity.Customer(){
                Phonenumber = cust.Phonenumber,
                Name = cust.Name,
                Password = cust.Password,
                Password1 = cust.Password2
            };

            //Adding the custToAdd obj to change tracker
            custToAdd = _context.Add(custToAdd).Entity;

            //the "changes" are not executed until I call the SaveChanges method
            _context.SaveChanges();

            //the below line clears the changetracker so it returns to a clean slate
            _context.ChangeTracker.Clear();

            return new Model.Customer()
            {
                Phonenumber = custToAdd.Phonenumber,
                Name = custToAdd.Name,
                Password = custToAdd.Password,
                Password2 = custToAdd.Password1
            };
        }

        public Store AddStore(Store store)
        {
            Entity.Store storeToAdd = new Entity.Store()
            {
                Number = store.Number,
                Location = store.Location,
                Zipcode = store.Zipcode,
                Managerphone = store.ManagerPhone
            };

            storeToAdd = _context.Add(storeToAdd).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Model.Store()
            {
                Number = storeToAdd.Number,
                Location = storeToAdd.Location,
                Zipcode = storeToAdd.Zipcode,
                ManagerPhone = storeToAdd.Managerphone
            };
        }

        public List<Model.Customer> GetLoggedInCustomer(string phonenumber, string password){
            List<Model.Customer> loggedInCust = new List<Model.Customer>();

            loggedInCust = _context.Customers.Where(
                cust => cust.Phonenumber.Contains(phonenumber) && cust.Password.Contains(password)
            ).Select(
                c => new Model.Customer(){
                    Phonenumber = c.Phonenumber,
                    Name = c.Name,
                    Password = c.Password
                }
            ).ToList();

            return loggedInCust;
        }

        public List<Model.Manager> GetManagers(string phonenumber, string password)
        {
            return _context.Managers.Where(manager => manager.Phonenumber.Contains(phonenumber) 
            && manager.Password.Contains(password)).Select(
                m => new Model.Manager(){
                    Phonenumber = m.Phonenumber,
                    Name = m.Name,
                    Password = m.Password
                }
            ).ToList();
        }

        public List<Model.Store> GetStores(string managerNumber)
        {
            return _context.Stores.Where(managerPhone => managerPhone.Managerphone.Contains(managerNumber))
            .Select(
                s => new Model.Store(){
                    Number = s.Number,
                    Location = s.Location,
                    Zipcode = s.Zipcode
                }
            ).ToList();
        }
    }
}