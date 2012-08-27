using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Hans.SinglePageApp.Core.Domains;

namespace Hans.SinglePageApp.Core.Mappings
{
    public class ShipperMap : ClassMap<Shipper>
    {
        public ShipperMap()
        {
            Table("Shippers");
            LazyLoad();
            Id(x => x.ShipperID).GeneratedBy.Identity().Column("ShipperID");
            Map(x => x.CompanyName).Column("CompanyName").Not.Nullable().Length(40);
            Map(x => x.Phone).Column("Phone").Length(24);

            HasMany(x => x.Orders)
                .KeyColumn("ShipVia")
                .AsBag()
                .Cascade.None()
                .LazyLoad();
        }
    }
}
