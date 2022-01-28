namespace ITF.Domain.Entities;

public class User
{
    public Guid Id { get; set; } // user id from jwt

    public DeveloperProfile? ApplicantProfile { get; set; }
    public Guid ApplicantProfileId { get; set; }

    public RecruiterProfile? EmployerProfile { get; set; }
    public Guid EmployerProfileId { get; set; }
}