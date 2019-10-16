using System;

namespace Tests.Repository.CheckInRepository
{
    public class Patient
    {
        public Guid PatientId { get; }

        public Patient(Guid patientId)
        {
            PatientId = patientId;
        }
    }
}