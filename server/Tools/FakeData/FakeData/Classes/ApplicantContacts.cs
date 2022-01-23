using System;

namespace FakeData
{
    public class ApplicantContacts
    {
        public Guid ApplicantProfileId { get; set; } // Also PK

        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Telegram { get; set; }
        public string PortfolioLink { get; set; }
        public string LinkedInLink { get; set; }
    }
}