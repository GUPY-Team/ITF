namespace FakeData;
public class EmployerProfile
    {
        public Guid UserId { get; set; } // Also PK

        public string FullName { get; set; }
        public string Position { get; set; }

        public CompanyInfo CompanyInfo { get; set; }
        public Guid CompanyInfoId { get; set; }

        public EmployerContacts EmployerContacts { get; set; }
        public Guid EmployerContactsId { get; set; }
    }