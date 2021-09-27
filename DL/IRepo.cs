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
        List<Store> GetManagerStores(string managerNumber);
        List<Store> GetCustomerStores();
        Product AddProduct(Product product);
        void AddToStoreProduct(string storeNumber, int productID);
        List<Product> GetProducts(string storeNumber);
        List<Customer> GetCustomerSearch(string name);
    }
}