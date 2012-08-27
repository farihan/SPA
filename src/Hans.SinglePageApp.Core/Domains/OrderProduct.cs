using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hans.SinglePageApp.Core.Domains
{
    public class OrderProduct
    {
        public virtual int OrderID { get; set; }
        public virtual int ProductID { get; set; }
        public virtual decimal UnitPrice { get; set; }
        public virtual short Quantity { get; set; }
        public virtual float Discount { get; set; }
        
        public override bool Equals(object obj)
        {
            if (obj == this) return true;
            if (obj == null) return false;

            if (this.OrderID != this.OrderID) return false;
            if (this.ProductID != this.ProductID) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return OrderID.GetHashCode() ^ ProductID.GetHashCode();
        }

        //belong to Order
        public virtual Order Order { get; set; }

        //belong to Product
        public virtual Product Product { get; set; }
    }
}
