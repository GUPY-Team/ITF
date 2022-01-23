using System;

namespace FakeData
{
    public class EmployerContacts
    {
        public Guid EmployerProfileId { get; set; } // Also PK

        public string PhoneNumber { get; set; }
        public string Telegram { get; set; }
        public string LinkedInLink { get; set; }
    }
}