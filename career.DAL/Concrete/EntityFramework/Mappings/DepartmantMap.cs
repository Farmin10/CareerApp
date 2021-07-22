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
    public class DepartmantMap : IEntityTypeConfiguration<Departmant>
    {
        public void Configure(EntityTypeBuilder<Departmant> builder)
        {
            builder.HasQueryFilter(e => e.IsDeleted == false);
            builder.HasData(
                new Departmant { DepartmantId = 10, Name = "Layihələndirmə", IsDeleted = false, ParentDepartmantId = null },
                new Departmant { DepartmantId = 11, Name = "Proqram təminatının hazırlanması", IsDeleted = false, ParentDepartmant = null },
                new Departmant { DepartmantId = 12, Name = "Ümumi ", IsDeleted = false, ParentDepartmant = null },
                new Departmant { DepartmantId = 13, Name = "Verilənlər bazasının idarə edilməsi və şəbəkə inzibatçılığı", IsDeleted = false, ParentDepartmant = null },
                new Departmant { DepartmantId = 14, Name = "Maliyyə", IsDeleted = false, ParentDepartmant = null }
                );
        }
    }
}
