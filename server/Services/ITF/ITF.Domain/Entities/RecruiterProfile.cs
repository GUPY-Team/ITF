namespace ITF.Domain.Entities;

public class RecruiterProfile
{
    public Guid Id { get; set; }

    public string FullName { get; set; }
    public string Position { get; set; }

    public string CompanyDescription { get; set; }
    public string CompanyWebsite { get; set; }

    public RecruiterContacts? EmployerContacts { get; set; }
    public Guid EmployerContactsId { get; set; }
}