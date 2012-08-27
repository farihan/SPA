using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hans.SinglePageApp.Core.Domains
{
    public class Region
    {
        public Region()
        {
            Territories = new List<Territory>();
        }

        public virtual int RegionID { get; set; }
        public virtual string RegionDescription { get; set; }

        //has many Territory
        public virtual IList<Territory> Territories { get; set; }
    }
}
