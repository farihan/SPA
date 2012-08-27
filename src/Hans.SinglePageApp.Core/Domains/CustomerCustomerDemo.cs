using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hans.SinglePageApp.Core.Domains
{
    public class CustomerCustomerDemo
    {
        public virtual string CustomerID { get; set; }
        public virtual string CustomerTypeID { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == this) return true;
            if (obj == null) return false;

            if (this.CustomerID != this.CustomerID) return false;
            if (this.CustomerTypeID != this.CustomerTypeID) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return CustomerID.GetHashCode() ^ CustomerTypeID.GetHashCode();
        }

        //belong to Customer
        public virtual Customer Customer { get; set; }

        //belong to CustomerDemographic
        public virtual CustomerDemographic CustomerDemographic { get; set; }
    }
}
