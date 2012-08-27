using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Hans.SinglePageApp.Core.Domains;

namespace Hans.SinglePageApp.Core.Mappings
{
    public class EmployeeMap : ClassMap<Employee>
    {
        public EmployeeMap()
        {
            Table("Employees");
            LazyLoad();
            Id(x => x.EmployeeID).GeneratedBy.Identity().Column("EmployeeID");
            Map(x => x.LastName).Column("LastName").Not.Nullable().Length(20);
            Map(x => x.FirstName).Column("FirstName").Not.Nullable().Length(10);
            Map(x => x.Title).Column("Title").Length(30);
            Map(x => x.TitleOfCourtesy).Column("TitleOfCourtesy").Length(25);
            Map(x => x.BirthDate).Column("BirthDate");
            Map(x => x.HireDate).Column("HireDate");
            Map(x => x.Address).Column("Address").Length(60);
            Map(x => x.City).Column("City").Length(15);
            Map(x => x.Region).Column("Region").Length(15);
            Map(x => x.PostalCode).Column("PostalCode").Length(10);
            Map(x => x.Country).Column("Country").Length(15);
            Map(x => x.HomePhone).Column("HomePhone").Length(24);
            Map(x => x.Extension).Column("Extension").Length(4);
            Map(x => x.Photo).Column("Photo").Length(2147483647);
            Map(x => x.Notes).Column("Notes").Length(1073741823);
            Map(x => x.PhotoPath).Column("PhotoPath").Length(255);

            References(x => x.ReportTo).Column("ReportsTo");

            HasMany(x => x.Employees)
                .KeyColumn("ReportsTo")
                .AsBag()
                .Cascade.None()
                .LazyLoad();
            HasMany(x => x.EmployeeTerritories)
                .Table("[EmployeeTerritories]")
                .Inverse()
                .LazyLoad()
                .Cascade.Delete()
                .KeyColumns.Add("EmployeeID");
            HasMany(x => x.Orders)
                .KeyColumn("EmployeeID")
                .AsBag()
                .Cascade.None()
                .LazyLoad();
        }
    }
}
