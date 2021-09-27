using System;
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

        public List<Customer> GetLoggedInCustomer(string phonenumber, string password){
            return _repo.GetLoggedInCustomer(phonenumber, password);
        }

        public Customer AddCustomer(Customer cust){
            return _repo.AddCustomer(cust);
        }

        public List<Manager> GetManagers(string phonenumber, string password)
        {
            return _repo.GetManagers(phonenumber, password);
        }

        public Store AddStore(Store store)
        {
            return _repo.AddStore(store);
        }

        public List<Store> GetManagerStores(string managerNumber)
        {
            return _repo.GetManagerStores(managerNumber);
        }

        public Product AddProduct(Product product)
        {
            return _repo.AddProduct(product);
        }

        public void AddToStoreProduct(string storeNumber, int productID)
        {
            _repo.AddToStoreProduct(storeNumber, productID);
        }

        public List<Product> GetProducts(string storeNumber)
        {
            return _repo.GetProducts(storeNumber);
        }

        public List<Customer> GetCustomerSearch(string name)
        {
            return _repo.GetCustomerSearch(name);
        }

        public List<Store> GetCustomerStores()
        {
            return _repo.GetCustomerStores();
        }
    }
}