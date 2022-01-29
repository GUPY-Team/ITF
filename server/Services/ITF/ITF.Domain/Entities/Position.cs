using ITF.Domain.Enums;

namespace ITF.Domain.Entities;

public class Position
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string City { get; set; } = null!;
    public int? ExperienceInYears { get; set; }
    public ICollection<WorkOption> WorkOptions { get; set; } = new List<WorkOption>();
}