using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmaBlockchainBackend.Infrastructure.Entities;

namespace PharmaBlockchainBackend.Infrastructure.Configuration
{
    internal class CmoConfiguration : IEntityTypeConfiguration<Cmo>
    {
        public void Configure(EntityTypeBuilder<Cmo> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(250);
        }
    }
}
