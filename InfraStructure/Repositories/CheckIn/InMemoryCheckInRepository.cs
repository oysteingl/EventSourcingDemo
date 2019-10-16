using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Features.CheckIn;

namespace InfraStructure.Repositories.CheckIn
{
    public class InMemoryCheckInRepository : ICheckInRepository
    {
        private readonly List<ICheckInEvent> _eventStream = new List<ICheckInEvent>();
        public async Task SaveChange(ICheckInChange checkInChange)
        {
            _eventStream.Add(CreateEvent(checkInChange));
        }

        private ICheckInEvent CreateEvent(ICheckInChange checkInChange)
        {
            return new CheckInChangedEvent(checkInChange.ChangeId, checkInChange.PatientId, checkInChange.CheckInStatus);
        }

        public IReadOnlyCollection<ICheckInEvent> GetEvents()
        {
            return _eventStream;
        }
    }
}