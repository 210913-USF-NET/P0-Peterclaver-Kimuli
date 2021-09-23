using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model = Models;
using Entity = DL.Entities;
using Microsoft.EntityFrameworkCore;

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
        
        public List<Model.Customer> GetCustomers(){
            throw new NotImplementedException();
        }

        public List<Model.Manager> GetManagers()
        {
            throw new NotImplementedException();
        }
    }
}