using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hans.SinglePageApp.Core.Domains
{
    public class Territory
    {
        public Territory()
        {
            EmployeeTerritories = new List<EmployeeTerritory>();
        }

        public virtual string TerritoryID { get; set; }
        public virtual string TerritoryDescription { get; set; }

        //belong to Region
        public virtual Region Region { get; set; }

        //has many EmployeeTerritory
        public virtual IList<EmployeeTerritory> EmployeeTerritories { get; set; }
    }
}
