// This is the store Model
using System;

namespace Models
{
    public class Store
    {
        public Store(){}

        public Store(int number, string location){
            this.Number = number;
            this.Location = location;
        }

        public int Number { get; set; }
        public string Location { get; set; }
    }
}