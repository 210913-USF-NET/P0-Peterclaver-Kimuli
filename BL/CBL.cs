using Models;
using DL;
using System.Collections.Generic;

namespace BL
{
    public class CBL : IBL
    {
        private IRepo _repo;

        public CBL(IRepo repo){
            _repo = repo;
        }

        public List<Customer> GetCustomers(){
            return _repo.GetCustomers();
        }

        public Customer AddCustomer(Customer cust){
            return _repo.AddCustomer(cust);
        }
    }
}