using FluentValidation;
using ITF.Application.DeveloperProfiles.Commands;

namespace ITF.Api.Validators.DeveloperProfiles;

public class CreateDeveloperProfileCommandValidator : AbstractValidator<CreateDeveloperProfileCommand>
{
    public CreateDeveloperProfileCommandValidator()
    {
        RuleFor(c => c.Position).NotEmpty();
        RuleFor(c => c.SalaryExpectation).GreaterThanOrEqualTo(100);
        RuleFor(c => c.HourlyRate)
            .GreaterThan(0)
            .When(c => c.HourlyRate != null);
        RuleFor(c => c.ExperienceInYears).GreaterThan(0).LessThanOrEqualTo(50);
        RuleFor(c => c.City).MaximumLength(1024);
        RuleFor(c => c.EnglishProficiency).IsInEnum();
        RuleFor(c => c.ExperienceDescription).MaximumLength(8192);
        RuleFor(c => c.Expectations).MaximumLength(1024);
        RuleFor(c => c.Achievements).MaximumLength(2048);
        RuleFor(c => c.DeveloperCategoryId).NotEmpty();
        RuleFor(c => c.Skills.Count).LessThanOrEqualTo(100);
        RuleFor(c => c.WorkOptions)
            .Must(c => c.Count == c.ToHashSet().Count)
            .ForEach(wo => wo.IsInEnum());
    }
}