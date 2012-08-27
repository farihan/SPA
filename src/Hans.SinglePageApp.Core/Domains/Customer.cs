using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hans.SinglePageApp.Core.Domains
{
    public class Customer
    {
        public Customer()
        {
            CustomerCustomerDemos = new List<CustomerCustomerDemo>();
            Orders = new List<Order>();
        }

        public virtual string CustomerID { get; set; }
        public virtual string CompanyName { get; set; }
        public virtual string ContactName { get; set; }
        public virtual string ContactTitle { get; set; }
        public virtual string Address { get; set; }
        public virtual string City { get; set; }
        public virtual string Region { get; set; }
        public virtual string PostalCode { get; set; }
        public virtual string Country { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Fax { get; set; }

        //has many CustomerCustomerDemo
        public virtual IList<CustomerCustomerDemo> CustomerCustomerDemos { get; set; }

        //has many Order
        public virtual IList<Order> Orders { get; set; }
    }
}
