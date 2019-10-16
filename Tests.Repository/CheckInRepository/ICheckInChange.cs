using System;

namespace Tests.Repository.CheckInRepository
{
    public interface ICheckInChange
    {
        CheckInStatus CheckInStatus { get; }
        Guid ChangeId { get; }
        Guid PatientId { get; }
    }
}