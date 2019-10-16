using System;

namespace Domain.Features.CheckIn
{
    public interface ICheckInChange
    {
        CheckInStatus CheckInStatus { get; }
        Guid ChangeId { get; }
        Guid PatientId { get; }
    }
}