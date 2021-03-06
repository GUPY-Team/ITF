using MediatR;

namespace ITF.Application.MyDeveloperProfile.Commands;

public class UpdateContactsCommand : IRequest
{
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Telegram { get; set; }
    public string? PortfolioLink { get; set; }
    public string? LinkedInLink { get; set; }
}