using MediatR;

namespace ITF.Application.DeveloperProfiles.Commands;

public class UpdateDeveloperContactsCommand : IRequest
{
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Telegram { get; set; }
    public string? PortfolioLink { get; set; }
    public string? LinkedInLink { get; set; }
}