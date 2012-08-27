using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Hans.SinglePageApp.Core.Domains;

namespace Hans.SinglePageApp.Core.Mappings
{
    public class CustomerCustomerDemoMap : ClassMap<CustomerCustomerDemo>
    {
        public CustomerCustomerDemoMap()
        {
            Table("CustomerCustomerDemo");
            LazyLoad();
            CompositeId().KeyProperty(x => x.CustomerID, "CustomerID").KeyProperty(x => x.CustomerTypeID, "CustomerTypeID");
            
            References(x => x.Customer).Column("CustomerID");            
            References(x => x.CustomerDemographic).Column("CustomerTypeID");
        }
    }
}
