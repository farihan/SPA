using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Hans.SinglePageApp.Core.Domains;

namespace Hans.SinglePageApp.Core.Mappings
{
    public class OrderMap : ClassMap<Order>
    {
        public OrderMap() {
			Table("Orders");
			LazyLoad();
			Id(x => x.OrderID).GeneratedBy.Identity().Column("OrderID");
			Map(x => x.OrderDate).Column("OrderDate");
			Map(x => x.RequiredDate).Column("RequiredDate");
			Map(x => x.ShippedDate).Column("ShippedDate");
			Map(x => x.Freight).Column("Freight");
			Map(x => x.ShipName).Column("ShipName").Length(40);
			Map(x => x.ShipAddress).Column("ShipAddress").Length(60);
			Map(x => x.ShipCity).Column("ShipCity").Length(15);
			Map(x => x.ShipRegion).Column("ShipRegion").Length(15);
			Map(x => x.ShipPostalCode).Column("ShipPostalCode").Length(10);
			Map(x => x.ShipCountry).Column("ShipCountry").Length(15);
            
			References(x => x.Customer).Column("CustomerID");
			References(x => x.Employee).Column("EmployeeID");
			References(x => x.Shipper).Column("ShipVia");

            HasMany(x => x.OrderProducts)
                .Table("[Order Details]")
                .Inverse()
                .LazyLoad()
                .Cascade.Delete()
                .KeyColumns.Add("OrderID");
        }
    }
}
