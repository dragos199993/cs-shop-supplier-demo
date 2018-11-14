using System;
using System.Collections.Generic;
using System.Text;

namespace ConsignmentShopLibrary
{
    public class Item
    {
        public Item()
        {
            Sold = false;
            PaymentDistributed = false;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool Sold { get; set; }
        public bool PaymentDistributed { get; set; }
        public Vendor Owner { get; set; }

        public string Display
        {
            get
            {
                return string.Format("{0} - ${1}", Title, Price);
            }
        }
    }
}
