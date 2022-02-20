namespace ITF.Domain.Entities;

public class RecruiterContacts
{
    public string? PhoneNumber { get; set; }
    public string? Telegram { get; set; }
    public string? LinkedInLink { get; set; }

    public RecruiterProfile? RecruiterProfile { get; set; }
    public Guid RecruiterProfileId { get; set; }
}