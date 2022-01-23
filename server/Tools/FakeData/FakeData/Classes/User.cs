using System;

namespace FakeData
{
    public class User
    {
        public Guid Id { get; set; } // user id from jwt

        public ApplicantProfile ApplicantProfile { get; set; }
        public Guid ApplicantProfileId { get; set; }

        public EmployerProfile EmployerProfile { get; set; }
        public Guid EmployerProfileId { get; set; }
    }
}