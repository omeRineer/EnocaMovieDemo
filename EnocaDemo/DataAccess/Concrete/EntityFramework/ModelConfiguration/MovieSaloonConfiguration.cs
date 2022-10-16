using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.ModelConfiguration
{
    public class MovieSaloonConfiguration : IEntityTypeConfiguration<MovieSaloon>
    {
        public void Configure(EntityTypeBuilder<MovieSaloon> builder)
        {
            builder.Property(x => x.MovieId)
                   .IsRequired();

            builder.Property(x => x.SaloonId)
                   .IsRequired();
        }
    }
}
