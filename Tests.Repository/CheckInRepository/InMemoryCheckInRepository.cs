using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tests.Repository.CheckInRepository
{
    public class InMemoryCheckInRepository
    {
        private readonly List<ICheckInEvent> _eventStream = new List<ICheckInEvent>();
        public async Task SaveChange(ICheckInChange checkInChange)
        {
            _eventStream.Add(CreateEvent(checkInChange));
        }

        private ICheckInEvent CreateEvent(ICheckInChange checkInChange)
        {
            return new CheckInChangedEvent {ChangeId = checkInChange.ChangeId, EventId = Guid.NewGuid(), CheckInStatus = checkInChange.CheckInStatus};
        }

        public IReadOnlyCollection<ICheckInEvent> GetEvents()
        {
            return _eventStream;
        }
    }
}