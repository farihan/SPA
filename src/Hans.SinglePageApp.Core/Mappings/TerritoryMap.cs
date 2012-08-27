using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Hans.SinglePageApp.Core.Domains;

namespace Hans.SinglePageApp.Core.Mappings
{
    public class TerritoryMap : ClassMap<Territory>
    {
        public TerritoryMap()
        {
            Table("Territories");
            LazyLoad();
            Id(x => x.TerritoryID).GeneratedBy.Assigned().Column("TerritoryID");
            Map(x => x.TerritoryDescription).Column("TerritoryDescription").Not.Nullable().Length(50);

            References(x => x.Region).Column("RegionID");

            HasMany(x => x.EmployeeTerritories)
                .Table("[EmployeeTerritories]")
                .Inverse()
                .LazyLoad()
                .Cascade.Delete()
                .KeyColumns.Add("TerritoryID");
        }
    }
}
