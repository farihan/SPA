using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Hans.SinglePageApp.Core.Domains;

namespace Hans.SinglePageApp.Core.Mappings
{
    public class CustomerDemographicMap : ClassMap<CustomerDemographic>
    {
        public CustomerDemographicMap()
        {
            Table("CustomerDemographics");
            LazyLoad();
            Id(x => x.CustomerTypeID).GeneratedBy.Assigned().Column("CustomerTypeID");
            Map(x => x.CustomerDesc).Column("CustomerDesc").Length(1073741823);

            HasMany(x => x.CustomerCustomerDemos)
                .Table("[OCustomerCustomerDemo]")
                .Inverse()
                .LazyLoad()
                .Cascade.Delete()
                .KeyColumns.Add("CustomerTypeID");
        }
    }
}
