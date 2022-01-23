namespace FakeData;
public class ApplicantProfile
    {
        public Guid UserId { get; set; } // Also PK

        public ICollection<EmploymentOption> EmploymentOptions { get; set; }
        public string Position { get; set; }
        public int SalaryExpectation { get; set; }
        public int HourlyRate { get; set; }
        public int? ExperienceInYears { get; set; }
        public string? City { get; set; }
        public EnglishProficiency EnglishProficiency { get; set; }
        public string? ExperienceDescription { get; set; }
        public string? Expectations { get; set; }
        public string? Achievements { get; set; }

        public ApplicantContacts ApplicantContacts { get; set; }
        public Guid ApplicantContactsId { get; set; }

        public Category Category { get; set; }
        public Guid CategoryId { get; set; }

        public ICollection<ApplicantSkill> Skills { get; set; }
    }