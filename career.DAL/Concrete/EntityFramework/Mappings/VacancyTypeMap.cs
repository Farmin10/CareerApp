using career.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace career.DAL.Concrete.EntityFramework.Mappings
{
    public class VacancyTypeMap : IEntityTypeConfiguration<VacancyType>
    {
        public void Configure(EntityTypeBuilder<VacancyType> builder)
        {
            builder.HasKey(vacancy => vacancy.VacancyTypeId);
            builder.HasData(
                new VacancyType { VacancyTypeId = 1, IsDeleted = false, Key = "intern", Name = "Təcrübə proqramı" },
                new VacancyType { VacancyTypeId = 2, IsDeleted = false, Key = "work", Name = "İş vakansiyası" }
                );
            builder.HasQueryFilter(e => e.IsDeleted == false);
        }
    }
}
