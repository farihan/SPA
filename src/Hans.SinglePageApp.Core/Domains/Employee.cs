using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hans.SinglePageApp.Core.Domains
{
    public class Employee
    {
        public Employee()
        {
            Employees = new List<Employee>();
            EmployeeTerritories = new List<EmployeeTerritory>();
            Orders = new List<Order>();
        }

        public virtual int EmployeeID { get; set; }
        public virtual string LastName { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string Title { get; set; }
        public virtual string TitleOfCourtesy { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual DateTime HireDate { get; set; }
        public virtual string Address { get; set; }
        public virtual string City { get; set; }
        public virtual string Region { get; set; }
        public virtual string PostalCode { get; set; }
        public virtual string Country { get; set; }
        public virtual string HomePhone { get; set; }
        public virtual string Extension { get; set; }
        public virtual byte[] Photo { get; set; }
        public virtual string Notes { get; set; }
        public virtual string PhotoPath { get; set; }

        //belong to Employee
        public virtual Employee ReportTo { get; set; }

        //has many Employee
        public virtual IList<Employee> Employees { get; set; }

        //has many EmployeeTerritory
        public virtual IList<EmployeeTerritory> EmployeeTerritories { get; set; }

        //has many Order
        public virtual IList<Order> Orders { get; set; }
    }
}
