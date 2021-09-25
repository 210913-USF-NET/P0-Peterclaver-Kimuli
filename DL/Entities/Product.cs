using System;
using System.Collections.Generic;

#nullable disable

namespace DL.Entities
{
    public partial class Product
    {
        public Product()
        {
            Lineitems = new HashSet<Lineitem>();
            Storeproducts = new HashSet<Storeproduct>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Unitprice { get; set; }

        public virtual ICollection<Lineitem> Lineitems { get; set; }
        public virtual ICollection<Storeproduct> Storeproducts { get; set; }
    }
}
