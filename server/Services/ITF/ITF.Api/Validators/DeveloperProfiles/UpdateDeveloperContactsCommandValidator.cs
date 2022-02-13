using FluentValidation;
using ITF.Application.DeveloperProfiles.Commands;

namespace ITF.Api.Validators.DeveloperProfiles;

public class UpdateDeveloperContactsCommandValidator : AbstractValidator<UpdateDeveloperContactsCommand>
{
    public UpdateDeveloperContactsCommandValidator()
    {
        RuleFor(c => c.FullName).MaximumLength(256);
        RuleFor(c => c.Email).EmailAddress();
        RuleFor(c => c.PhoneNumber).MaximumLength(256);
        RuleFor(c => c.Telegram).MaximumLength(256);
        RuleFor(c => c.PortfolioLink).MaximumLength(256);
        RuleFor(c => c.LinkedInLink).MaximumLength(256);
    }
}