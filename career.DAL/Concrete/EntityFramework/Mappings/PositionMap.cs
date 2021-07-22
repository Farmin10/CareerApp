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
    public class PositionMap : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.HasQueryFilter(e => e.IsDeleted == false);
            builder.HasData(
                new Position { PositionId = 10, Name = "Kiçik mütəxəssis", IsDeleted = false, DepartmantId = 11 },
                new Position { PositionId = 11, Name = "Mütəxəssis", IsDeleted = false, DepartmantId = 12 },
                new Position { PositionId = 12, Name = "Apararıcı mütəxəssis", IsDeleted = false, DepartmantId = 13 },
                new Position { PositionId = 13, Name = "Baş mütəxəssis", IsDeleted = false, DepartmantId = 12 },
                new Position { PositionId = 14, Name = "Sektor müdiri", IsDeleted = false, DepartmantId = 14 },
                new Position { PositionId = 15, Name = "Şöbə müdiri", IsDeleted = false, DepartmantId = 10 },
                new Position { PositionId = 16, Name = "Direktor müavini", IsDeleted = false, DepartmantId = 14 },
                new Position { PositionId = 17, Name = "Direktor", IsDeleted = false, DepartmantId = 13 }
                );
        }
    }
}
