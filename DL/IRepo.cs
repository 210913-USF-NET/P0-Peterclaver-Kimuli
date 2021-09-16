using Models;
using System.Collections.Generic;

namespace DL
{
    public interface IRepo
    {
        Customer AddCustomer(Customer cust);
        List<Customer> GetCustomers();
    }
}