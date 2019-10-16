using System;

namespace Tests.Repository.CheckInRepository
{
    public interface ICheckInChange
    {
        CheckInStatus CheckInStatus { get; set; }
        Guid ChangeId { get; set; }
    }
}