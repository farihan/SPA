using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Hans.SinglePageApp.Core.Domains;

namespace Hans.SinglePageApp.Core.Mappings
{
    public class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Table("Categories");
            LazyLoad();
            Id(x => x.CategoryID).GeneratedBy.Identity().Column("CategoryID");
            Map(x => x.CategoryName).Column("CategoryName").Not.Nullable().Length(15);
            Map(x => x.Description).Column("Description").Length(1073741823);
            Map(x => x.Picture).Column("Picture").Length(2147483647);

            HasMany(x => x.Products)
                .KeyColumn("CategoryID")
                .AsBag()
                .Cascade.None()
                .LazyLoad();
        }
    }
}
