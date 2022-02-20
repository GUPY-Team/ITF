using ITF.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITF.Infrastructure.EntityConfigurations;

public class RecruiterProfileConfiguration : IEntityTypeConfiguration<RecruiterProfile>
{
    public void Configure(EntityTypeBuilder<RecruiterProfile> builder)
    {
        builder.HasOne(rp => rp.RecruiterContacts)
            .WithOne(rc => rc.RecruiterProfile)
            .HasForeignKey<RecruiterContacts>(rc => rc.RecruiterProfileId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(rp => rp.Positions)
            .WithOne(p => p.RecruiterProfile)
            .HasForeignKey(p => p.RecruiterProfileId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}