using ITF.Domain.Enums;
using MediatR;

namespace ITF.Application.MyDeveloperProfile.Commands;

public class UpdateProfileCommand : IRequest
{
    public string Position { get; set; } = null!;
    public int SalaryExpectation { get; set; }
    public int? HourlyRate { get; set; }
    public int? ExperienceInYears { get; set; }
    public string? City { get; set; }
    public EnglishProficiency EnglishProficiency { get; set; }
    public string? ExperienceDescription { get; set; }
    public string? Expectations { get; set; }
    public string? Achievements { get; set; }

    public Guid DeveloperCategoryId { get; set; }

    public List<string> Skills { get; set; } = new();
    public List<WorkOption> WorkOptions { get; set; } = new();
}