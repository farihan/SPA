using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hans.SinglePageApp.Core.Domains
{
    public class Category
    {
        public Category()
        {
            Products = new List<Product>();
        }

        public virtual int CategoryID { get; set; }
        public virtual string CategoryName { get; set; }
        public virtual string Description { get; set; }
        public virtual byte[] Picture { get; set; }

        //has many Product
        public virtual IList<Product> Products { get; set; }
    }
}
