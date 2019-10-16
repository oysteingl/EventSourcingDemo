using System;

namespace Domain.Features.CheckIn
{
    public class CheckInEventFactory
    {
        public static CheckInChangedEvent Create(Guid patientId, CheckInStatus status, DateTime dateTime) => new CheckInChangedEvent(Guid.NewGuid(), patientId, status, new DateTimeOffset(dateTime).ToUnixTimeSeconds());
    }
}