// This is the customer model
using System;

namespace Models
{
    public class Customer
    {
        public Customer(){}

        //Constructor overloading
        public Customer(string name, string email, string password, string phonenumber, int zipcode){
            this.Name = name;
            this.Email = email;
            this.Phonenumber = phonenumber;
            this.Zipcode = zipcode;
            this.Password = password;
        }

        //Setting properties
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        public int Zipcode { get; set; }
        public string Password { get; set; }

        public override string ToString(){
            return $"Name: {this.Name}";
        }
    }
}