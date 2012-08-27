using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Hans.SinglePageApp.Core.Domains;

namespace Hans.SinglePageApp.Core.Mappings
{
    public class RegionMap : ClassMap<Region>
    {
        public RegionMap()
        {
            Table("Region");
            LazyLoad();
            Id(x => x.RegionID).GeneratedBy.Identity().Column("RegionID");
            Map(x => x.RegionDescription).Column("RegionDescription").Not.Nullable().Length(50);

            HasMany(x => x.Territories)
                .KeyColumn("RegionID")
                .AsBag()
                .Cascade.None()
                .LazyLoad();
        }
    }
}
