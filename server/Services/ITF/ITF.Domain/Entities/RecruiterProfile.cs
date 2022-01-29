namespace ITF.Domain.Entities;

public class RecruiterProfile
{
    public Guid Id { get; set; }

    public string FullName { get; set; } = null!;
    public string Position { get; set; } = null!;

    public string CompanyDescription { get; set; } = null!;
    public string? CompanyWebsite { get; set; }

    public RecruiterContacts? RecruiterContacts { get; set; }
    public Guid RecruiterContactsId { get; set; }

    public ICollection<Position> Positions { get; set; } = new List<Position>();
}