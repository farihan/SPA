using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Hans.SinglePageApp.Core.Domains;

namespace Hans.SinglePageApp.Core.Mappings
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap() {
			Table("Products");
			LazyLoad();
			Id(x => x.ProductID).GeneratedBy.Identity().Column("ProductID");
			Map(x => x.ProductName).Column("ProductName").Not.Nullable().Length(40);
			Map(x => x.QuantityPerUnit).Column("QuantityPerUnit").Length(20);
			Map(x => x.UnitPrice).Column("UnitPrice");
			Map(x => x.UnitsInStock).Column("UnitsInStock");
			Map(x => x.UnitsOnOrder).Column("UnitsOnOrder");
			Map(x => x.ReorderLevel).Column("ReorderLevel");
			Map(x => x.Discontinued).Column("Discontinued").Not.Nullable();
            
			References(x => x.Supplier).Column("SupplierID");
			References(x => x.Category).Column("CategoryID");

            HasMany(x => x.OrderProducts)
                .Table("[Order Details]")
                .Inverse()
                .LazyLoad()
                .Cascade.Delete()
                .KeyColumns.Add("ProductID");
        }
    }
}
