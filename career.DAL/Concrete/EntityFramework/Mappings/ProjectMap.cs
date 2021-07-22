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
    public class ProjectMap : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasQueryFilter(e => e.IsDeleted == false);
        }
    }
}
