using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hans.SinglePageApp.Core.Domains
{
    public class CustomerDemographic
    {
        public CustomerDemographic()
        {
            CustomerCustomerDemos = new List<CustomerCustomerDemo>();
        }

        public virtual string CustomerTypeID { get; set; }
        public virtual string CustomerDesc { get; set; }

        //has many CustomerCustomerDemo
        public virtual IList<CustomerCustomerDemo> CustomerCustomerDemos { get; set; }
    }
}
