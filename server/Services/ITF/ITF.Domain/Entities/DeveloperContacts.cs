namespace ITF.Domain.Entities;

public class DeveloperContacts
{
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Telegram { get; set; }
    public string? PortfolioLink { get; set; }
    public string? LinkedInLink { get; set; }

    public DeveloperProfile? DeveloperProfile { get; set; }
    public Guid DeveloperProfileId { get; set; }
}