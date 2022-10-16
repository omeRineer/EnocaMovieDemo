using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.ModelConfiguration
{
    public class DirectorConfiguration : IEntityTypeConfiguration<Director>
    {
        public void Configure(EntityTypeBuilder<Director> builder)
        {
            builder.Property(x => x.FirstName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.LastName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasMany(x => x.Movies)
                   .WithOne(x => x.Director)
                   .HasForeignKey(x => x.DirectorId);
        }
    }
}
