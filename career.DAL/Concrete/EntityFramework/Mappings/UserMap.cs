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
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.UserId);
            builder.HasQueryFilter(e => e.IsDeleted == false);
            builder.HasOne(c => c.Employee).WithMany(e => e.Users).OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
