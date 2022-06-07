using ITF.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITF.Infrastructure.EntityConfigurations;

public class DeveloperContactsConfiguration : IEntityTypeConfiguration<DeveloperContacts>
{
    public void Configure(EntityTypeBuilder<DeveloperContacts> builder)
    {
        builder.HasKey(dc => dc.DeveloperProfileId);
    }
}