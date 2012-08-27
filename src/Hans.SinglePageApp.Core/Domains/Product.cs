using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hans.SinglePageApp.Core.Domains
{
    public class Product
    {
        public Product()
        {
            OrderProducts = new List<OrderProduct>();
        }

        public virtual int ProductID { get; set; }
        public virtual string ProductName { get; set; }
        public virtual int SupplierId { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual string QuantityPerUnit { get; set; }
        public virtual double UnitPrice { get; set; }
        public virtual int UnitsInStock { get; set; }
        public virtual int UnitsOnOrder { get; set; }
        public virtual int ReorderLevel { get; set; }
        public virtual bool Discontinued { get; set; }

        //has many OrderProducts
        public virtual IList<OrderProduct> OrderProducts { get; set; }
        
        //belong to Category
        public virtual Category Category { get; set; }

        //belong to Supplier
        public virtual Supplier Supplier { get; set; }
    }
}
