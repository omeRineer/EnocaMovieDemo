using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.ModelConfiguration
{
    public class SaloonConfiguration : IEntityTypeConfiguration<Saloon>
    {
        public void Configure(EntityTypeBuilder<Saloon> builder)
        {
            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasMany(x => x.MovieSaloons)
                   .WithOne(x => x.Saloon)
                   .HasForeignKey(x => x.SaloonId);

        }
    }
}
