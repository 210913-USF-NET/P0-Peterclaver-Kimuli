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

        //Add a product to the DB
        public Product AddProduct(Product product)
        {
            Entity.Product newProduct = new Entity.Product()
            {
                Name = product.Name,
                Stock = product.Quantity,
                Unitprice = product.UnitPrice,
                Storeid = product.StoreID
            };

            newProduct = _context.Add(newProduct).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Model.Product()
            {
                Id = newProduct.Id,
                Name = newProduct.Name,
                Quantity = newProduct.Stock,
                UnitPrice = newProduct.Unitprice
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

        public void AddToStoreProduct(string storeNumber, int productID)
        {
            Entity.Storeproduct storeProduct = new Entity.Storeproduct()
            {
                Storeid = storeNumber,
                Productid = productID
            };

            storeProduct = _context.Add(storeProduct).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }

        public List<Customer> GetCustomerSearch(string name)
        {
            return _context.Customers.Where(custName => custName.Name.Contains(name)).Select(
                c => new Model.Customer(){
                    Phonenumber = c.Phonenumber,
                    Name = c.Name
                }
            ).ToList();
        }

        public List<Model.Customer> GetLoggedInCustomer(string phonenumber, string password){
            List<Model.Customer> loggedInCust = new List<Model.Customer>();

            loggedInCust = _context.Customers.Where(
                cust => cust.Phonenumber == phonenumber && cust.Password == password
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
            return _context.Managers.Where(manager => manager.Phonenumber == phonenumber
            && manager.Password == password).Select(
                m => new Model.Manager(){
                    Phonenumber = m.Phonenumber,
                    Name = m.Name,
                    Password = m.Password
                }
            ).ToList();
        }

        public List<Product> GetProducts(string storeNumber)
        {
            /* List <Entity.Storeproduct> products = _context.Storeproducts.
            Include(p => p.Product).Where(p => p.Storeid == storeNumber).ToList(); */
            
            return _context.Products.Where(p => p.Storeid == storeNumber).Select(
                sp => new Model.Product(){
                    Id = sp.Id,
                    Name = sp.Name,
                    Quantity = sp.Stock,
                    UnitPrice = sp.Unitprice,
                    StoreID = sp.Storeid
                }
            ).ToList();
            
        }
        public List<Model.Store> GetManagerStores(string managerNumber)
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
        public List<Model.Store> GetCustomerStores()
        {
            return _context.Stores.Select(
                s => new Model.Store(){
                    Number = s.Number,
                    Location = s.Location,
                    Zipcode = s.Zipcode
                }
            ).ToList();
        }
        public Order AddOrder(Order order)
        {
            Entity.Customerorder newOrder = new Entity.Customerorder()
            {
                Total = order.Total,
                Customerphone = order.CustomerPhone,
                Storeid = order.StoreID,
                Orderdate = order.OrderDate
            };

            newOrder = _context.Add(newOrder).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Model.Order(){
                Id = newOrder.Id,
                Total = newOrder.Total,
                CustomerPhone = newOrder.Customerphone,
                StoreID = newOrder.Storeid,
                OrderDate = newOrder.Orderdate
            };
        }

        public List<LineItem> AddLineItems(List<LineItem> items)
        {
            List<Model.LineItem> addedItems = new List<LineItem>();

            for(int i = 0; i < items.Count; i++)
            {
                Entity.Lineitem newItem = new Entity.Lineitem()
                {
                    Id = items[i].Id,
                    Orderid = items[i].OrderId,
                    Productid = items[i].ProductId,
                    Productname = items[i].ProductName,
                    Quantity = items[i].Quantity,
                    Cost = items[i].Cost
                };

                newItem = _context.Add(newItem).Entity;
                _context.SaveChanges();
                _context.ChangeTracker.Clear();

                addedItems.Add(new Model.LineItem(){
                    Id = newItem.Id,
                    OrderId = newItem.Orderid,
                    ProductId = newItem.Productid,
                    ProductName = newItem.Productname,
                    Quantity = newItem.Quantity,
                    Cost = newItem.Cost
                });
            }

            return addedItems;
        }

        public List<Order> GetCustomerOrders(string customerNumber)
        {
            return _context.Customerorders.OrderBy(o =>o.Orderdate).Include(cn => cn.Lineitems).
            Where(cn => cn.Customerphone == customerNumber).Select(
                o => new Model.Order(){
                    Id = o.Id,
                    OrderDate = o.Orderdate,
                    Total = o.Total,
                    StoreID = o.Storeid,
                    Items = o.Lineitems.Select(i => new Model.LineItem(){
                        ProductName = i.Productname,
                        Quantity = i.Quantity,
                        Cost = i.Cost,
                    }).ToList()
                }
            ).ToList();
        }

        public List<Order> GetCustomerOrdersByCost(string customerNumber)
        {
            return _context.Customerorders.OrderBy(o =>o.Total).Include(cn => cn.Lineitems).
            Where(cn => cn.Customerphone == customerNumber).Select(
                o => new Model.Order(){
                    Id = o.Id,
                    OrderDate = o.Orderdate,
                    Total = o.Total,
                    StoreID = o.Storeid,
                    Items = o.Lineitems.Select(i => new Model.LineItem(){
                        ProductName = i.Productname,
                        Quantity = i.Quantity,
                        Cost = i.Cost,
                    }).ToList()
                }
            ).ToList();
        }

        public List<Order> GetStoreOrders(string storeNumber)
        {
            return _context.Customerorders.OrderBy(o =>o.Orderdate).Include(cn => cn.Lineitems).
            Where(cn => cn.Storeid == storeNumber).Select(
                o => new Model.Order(){
                    Id = o.Id,
                    OrderDate = o.Orderdate,
                    Total = o.Total,
                    StoreID = o.Storeid,
                    CustomerName = o.CustomerphoneNavigation.Name,
                    Items = o.Lineitems.Select(i => new Model.LineItem(){
                        ProductName = i.Productname,
                        Quantity = i.Quantity,
                        Cost = i.Cost,
                    }).ToList()
                }
            ).ToList();
        }
        public List<Order> GetStoreOrdersByCost(string storeNumber)
        {
            return _context.Customerorders.OrderBy(o =>o.Total).Include(cn => cn.Lineitems).
            Where(cn => cn.Storeid == storeNumber).Select(
                o => new Model.Order(){
                    Id = o.Id,
                    OrderDate = o.Orderdate,
                    Total = o.Total,
                    StoreID = o.Storeid,
                    CustomerName = o.CustomerphoneNavigation.Name,
                    Items = o.Lineitems.Select(i => new Model.LineItem(){
                        ProductName = i.Productname,
                        Quantity = i.Quantity,
                        Cost = i.Cost,
                    }).ToList()
                }
            ).ToList();
        }

        public void UpdateProduct(Product product)
        {
            Entity.Product updateProduct = new Entity.Product()
            {
                Id = product.Id,
                Name = product.Name,
                Stock = product.Quantity,
                Unitprice = product.UnitPrice,
                Storeid = product.StoreID
            };

            updateProduct = _context.Products.Update(updateProduct).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }
    }
}