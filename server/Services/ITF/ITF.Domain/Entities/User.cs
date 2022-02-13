using ITF.Domain.Enums;

namespace ITF.Domain.Entities;

public class User
{
    public Guid Id { get; set; }

    public ProfileType SelectedProfile { get; set; }

    public DeveloperProfile? DeveloperProfile { get; set; }
    public RecruiterProfile? RecruiterProfile { get; set; }
}