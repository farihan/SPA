using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Hans.SinglePageApp.Core.Domains;

namespace Hans.SinglePageApp.Core.Mappings
{
    public class EmployeeTerritoryMap : ClassMap<EmployeeTerritory>
    {
        public EmployeeTerritoryMap()
        {
            Table("EmployeeTerritories");
            LazyLoad();
            CompositeId().KeyProperty(x => x.EmployeeID, "EmployeeID").KeyProperty(x => x.TerritoryID, "TerritoryID");

            References(x => x.Employee).Column("EmployeeID");
            References(x => x.Territory).Column("TerritoryID");
        }
    }
}
