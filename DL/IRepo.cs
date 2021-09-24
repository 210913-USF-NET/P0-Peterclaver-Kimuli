using Models;
using System.Collections.Generic;

namespace DL
{
    public interface IRepo
    {
        Customer AddCustomer(Customer cust);
        List<Customer> GetLoggedInCustomer(string phonenumber, string password);
        List<Manager> GetManagers(string phonenumber, string password);
        Store AddStore(Store store);
    }
}