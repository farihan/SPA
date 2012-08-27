using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Hans.SinglePageApp.Core.Domains;

namespace Hans.SinglePageApp.Core.Mappings
{
    public class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            Table("Customers");
            LazyLoad();
            Id(x => x.CustomerID).GeneratedBy.Assigned().Column("CustomerID");
            Map(x => x.CompanyName).Column("CompanyName").Not.Nullable().Length(40);
            Map(x => x.ContactName).Column("ContactName").Length(30);
            Map(x => x.ContactTitle).Column("ContactTitle").Length(30);
            Map(x => x.Address).Column("Address").Length(60);
            Map(x => x.City).Column("City").Length(15);
            Map(x => x.Region).Column("Region").Length(15);
            Map(x => x.PostalCode).Column("PostalCode").Length(10);
            Map(x => x.Country).Column("Country").Length(15);
            Map(x => x.Phone).Column("Phone").Length(24);
            Map(x => x.Fax).Column("Fax").Length(24);

            HasMany(x => x.CustomerCustomerDemos)
                .Table("[OCustomerCustomerDemo]")
                .Inverse()
                .LazyLoad()
                .Cascade.Delete()
                .KeyColumns.Add("CustomerID");
            HasMany(x => x.Orders)
                .KeyColumn("CustomerID")
                .AsBag()
                .Cascade.None()
                .LazyLoad();
        }
    }
}
