// This is the customer model
using System;
using System.Text.RegularExpressions;
using Serilog;

namespace Models
{
    public class Customer
    {
        public Customer(){}

        public Customer(string name, string phonenumber, string password){
            this.Name = name;
            this.Phonenumber = phonenumber;
            this.Password = password;
        }

        //creating name validation
        private string _name;

        //Setting properties
        public string Name
         { get
         {
             return _name;
         } 
         set
         {
             Regex pattern = new Regex("^[a-zA-Z ]+$");

             if(value.Length == 0){
                InputInvalidException e = new InputInvalidException("Name cannot be empty");
                Log.Warning(e.Message);
                throw e;
            }
            else if(!pattern.IsMatch(value)){
                InputInvalidException e = new InputInvalidException("Name can only have alphabetical characters!");
                Log.Warning(e.Message);
                throw e;
            }
            else{
                _name = value;
            }

         } }
        
        //creating phone validation
        private string _phonenumber;
        public string Phonenumber 
        { get
        {
            return _phonenumber;
        } 
        set
        {
            Regex pattern = new Regex("^[0-9]+$");
            if (value.Length == 0)
            {
                InputInvalidException e = new InputInvalidException("Phonenumber cannot be empty.");
                Log.Warning(e.Message);
                throw e;
            }
            else if(!pattern.IsMatch(value)){
                InputInvalidException e = new InputInvalidException("Phonenumber can only have numbers!");
                Log.Warning(e.Message);
                throw e;
            }
            else if(value.Length != 10){
                throw new InputInvalidException("Phonenumber is not complete!");
            }
            else{
                _phonenumber = value;
            }

        } }
        
        //creating password validation
        private string _password;
        public string Password
        { get
        {
            return _password;
        } 
        set
        {
            if (value.Length == 0)
            {
                InputInvalidException e = new InputInvalidException("Password cannot be empty.");
                Log.Warning(e.Message);
                throw e;
            }
            else if(value.Length < 4){
                InputInvalidException e = new InputInvalidException("Password should have 4 or more characters.");
                Log.Warning(e.Message);
                throw e;
            }
            else{
                _password = value;
            }

        } }

        public override string ToString(){
            return $"Name: {this.Name}, Phone Number:{this.Phonenumber}\n";
        }
    }
}