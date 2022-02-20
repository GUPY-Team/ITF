using ITF.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITF.Infrastructure.EntityConfigurations;

public class DeveloperProfileConfiguration : IEntityTypeConfiguration<DeveloperProfile>
{
    public void Configure(EntityTypeBuilder<DeveloperProfile> builder)
    {
        builder.HasOne(dp => dp.DeveloperContacts)
            .WithOne(dc => dc.DeveloperProfile)
            .HasForeignKey<DeveloperContacts>(c => c.DeveloperProfileId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}