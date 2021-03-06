using ITF.Domain.Enums;

namespace ITF.Domain.Entities;

public class DeveloperProfile
{
    public Guid Id { get; set; }

    public string Position { get; set; } = null!;
    public int SalaryExpectation { get; set; }
    public int? HourlyRate { get; set; }
    public int? ExperienceInYears { get; set; }
    public string? City { get; set; }
    public EnglishProficiency EnglishProficiency { get; set; } = EnglishProficiency.None;
    public string? ExperienceDescription { get; set; }
    public string? Expectations { get; set; }
    public string? Achievements { get; set; }

    public bool IsActive { get; set; }

    public DeveloperContacts? DeveloperContacts { get; set; }

    public DeveloperCategory? DeveloperCategory { get; set; }
    public Guid DeveloperCategoryId { get; set; }

    public List<string> Skills { get; set; } = new();
    public List<WorkOption> WorkOptions { get; set; } = new();

}