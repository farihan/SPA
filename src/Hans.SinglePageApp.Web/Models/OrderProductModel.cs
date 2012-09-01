using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hans.SinglePageApp.Web.Models
{
    public class OrderProductModel
    {
        public int OrderID { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }
    }
}