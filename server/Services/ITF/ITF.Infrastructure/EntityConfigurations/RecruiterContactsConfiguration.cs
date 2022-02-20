using ITF.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITF.Infrastructure.EntityConfigurations;

public class RecruiterContactsConfiguration : IEntityTypeConfiguration<RecruiterContacts>
{
    public void Configure(EntityTypeBuilder<RecruiterContacts> builder)
    {
        builder.HasKey(rc => rc.RecruiterProfileId);
    }
}