using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hans.SinglePageApp.Core.Domains
{
    public class EmployeeTerritory
    {
        public virtual int EmployeeID { get; set; }
        public virtual string TerritoryID { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == this) return true;
            if (obj == null) return false;

            if (this.EmployeeID != this.EmployeeID) return false;
            if (this.TerritoryID != this.TerritoryID) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return EmployeeID.GetHashCode() ^ TerritoryID.GetHashCode();
        }

        //belong to Employee
        public virtual Employee Employee { get; set; }

        //belong to Territory
        public virtual Territory Territory { get; set; }
    }
}
