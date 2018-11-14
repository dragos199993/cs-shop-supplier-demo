using System;
using System.Collections.Generic;
using System.Text;

namespace ConsignmentShopLibrary
{
    public class Vendor
    {
        public Vendor()
        {
            Commision = .5;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Commision { get; set; }
        public decimal PaymentDue { get; set; }


        public string Display
        {
            get
            {
                return string.Format("{0} {1} - ${2}", FirstName, LastName, PaymentDue);
            }
        }

    }
}
