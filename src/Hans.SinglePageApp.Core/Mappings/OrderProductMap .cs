using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Hans.SinglePageApp.Core.Domains;

namespace Hans.SinglePageApp.Core.Mappings
{
    public class OrderDetailsMap : ClassMap<OrderProduct>
    {
        public OrderDetailsMap()
        {
            Table("[Order Details]");
            LazyLoad();
            CompositeId().KeyProperty(x => x.OrderID, "OrderID").KeyProperty(x => x.ProductID, "ProductID");
            Map(x => x.UnitPrice).Column("UnitPrice").Not.Nullable();
            Map(x => x.Quantity).Column("Quantity").Not.Nullable();
            Map(x => x.Discount).Column("Discount").Not.Nullable();

            References(x => x.Order).Column("OrderID");
            References(x => x.Product).Column("ProductID");
        }
    }
}
