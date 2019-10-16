using System;

namespace Domain.Features.CheckIn
{
    public class CheckInChange : ICheckInChange
    {
        public CheckInChange(CheckInStatus checkInStatus, Guid changeId, Guid patientId)
        {
            CheckInStatus = checkInStatus;
            ChangeId = changeId;
            PatientId = patientId;
        }
        
        public CheckInStatus CheckInStatus { get; }
        public Guid ChangeId { get;}
        public Guid PatientId { get;}
    }
}