namespace FakeData;
public class CompanyInfo
    {
        public Guid EmployerProfileId { get; set; } // Also PK

        public string CompanyDescription { get; set; }
        public string CompanyWebsite { get; set; }
    }