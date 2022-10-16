using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.ModelConfiguration
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.GenreId)
                   .IsRequired();

            builder.Property(x => x.DirectorId)
                   .IsRequired();

            builder.Property(x => x.Year)
                   .IsRequired();

            builder.HasMany(x => x.MovieSaloons)
                   .WithOne(x => x.Movie)
                   .HasForeignKey(x => x.MovieId);
        }
    }
}
