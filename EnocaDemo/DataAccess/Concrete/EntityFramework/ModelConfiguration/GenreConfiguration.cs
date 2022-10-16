﻿using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.ModelConfiguration
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.Property(x => x.Name)
                   .IsRequired();

            builder.HasMany(x=>x.Movies)
                   .WithOne(x => x.Genre)
                   .HasForeignKey(x => x.GenreId);

        }
    }
}
