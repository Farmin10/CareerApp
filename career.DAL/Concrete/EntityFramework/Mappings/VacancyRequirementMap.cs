﻿using career.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace career.DAL.Concrete.EntityFramework.Mappings
{
    public class VacancyRequirementMap : IEntityTypeConfiguration<VacancyRequirement>
    {
        public void Configure(EntityTypeBuilder<VacancyRequirement> builder)
        {
            builder.HasKey(vacancy => vacancy.VacancyRequirementId);
            builder.HasQueryFilter(e => e.IsDeleted == false);
        }
    }
}
