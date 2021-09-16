using Models;
using System.Collections.Generic;
using DL;

namespace BL
{
    public interface IBL
    {
        Customer AddCustomer(Customer cust);
        List<Customer> GetCustomers();
    }
}