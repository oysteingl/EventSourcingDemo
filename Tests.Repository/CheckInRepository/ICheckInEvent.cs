using System;

namespace Tests.Repository.CheckInRepository
{
    public interface ICheckInEvent
    {
        Guid EventId { get; set; }
        Guid ChangeId { get; set; }
    }
}