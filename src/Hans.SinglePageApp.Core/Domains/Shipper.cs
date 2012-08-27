using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hans.SinglePageApp.Core.Domains
{
    public class Shipper
    {
        public Shipper()
        {
            Orders = new List<Order>();
        }

        public virtual int ShipperID { get; set; }
        public virtual string CompanyName { get; set; }
        public virtual string Phone { get; set; }

        //has many Order
        public virtual IList<Order> Orders { get; set; }
    }
}
