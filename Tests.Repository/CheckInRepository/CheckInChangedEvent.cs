using System;

namespace Tests.Repository.CheckInRepository
{
    public class CheckInChangedEvent : ICheckInEvent
    {
        public Guid EventId { get; set; }
        public Guid ChangeId { get; set; }
        public CheckInStatus CheckInStatus { get; set; }
    }
}