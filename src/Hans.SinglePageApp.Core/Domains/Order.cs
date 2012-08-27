using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hans.SinglePageApp.Core.Domains
{
    public class Order
    {
        public Order() {
            OrderProducts = new List<OrderProduct>();
        }

        public virtual int OrderID { get; set; }
        public virtual DateTime OrderDate { get; set; }
        public virtual DateTime RequiredDate { get; set; }
        public virtual DateTime ShippedDate { get; set; }
        public virtual decimal Freight { get; set; }
        public virtual string ShipName { get; set; }
        public virtual string ShipAddress { get; set; }
        public virtual string ShipCity { get; set; }
        public virtual string ShipRegion { get; set; }
        public virtual string ShipPostalCode { get; set; }
        public virtual string ShipCountry { get; set; }

        //has many OrderDetails
        public virtual IList<OrderProduct> OrderProducts { get; set; }

        //belong to Customer
        public virtual Customer Customer { get; set; }

        //belong to Employee
        public virtual Employee Employee { get; set; }

        //belong to Shipper
        public virtual Shipper Shipper { get; set; }
    }
}
