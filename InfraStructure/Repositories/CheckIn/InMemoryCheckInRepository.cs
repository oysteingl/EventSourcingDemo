using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Features.CheckIn;
using Utilities;

namespace InfraStructure.Repositories.CheckIn
{
    public class InMemoryCheckInRepository : ICheckInRepository
    {
        public InMemoryCheckInRepository()
        {
            _random = new Random();
            
            RefreshEventStream();
        }

        private void RefreshEventStream()
        {
            var patients = Enumerable.Range(1, 10).Select(_ => Guid.NewGuid()).ToList();
            _events = Enumerable.Range(1, 100).Select(i =>
            {
                var patientId = patients.RandomElementUsing(_random);
                var status = IEnumerableExtensions.RandomEnumValue<CheckInStatus>(_random);
                var date = new Bogus.DataSets.Date().Between(DateTime.Today.AddYears(-1), DateTime.Today);
                return CheckInEventFactory.Create(patientId, status, date);
            }).ToList();
        }

        private readonly List<ICheckInEvent> _eventStream = new List<ICheckInEvent>();
        private Random _random;

        public async Task SaveChange(ICheckInChange checkInChange)
        {
            _eventStream.Add(CreateEvent(checkInChange));
        }

        private ICheckInEvent CreateEvent(ICheckInChange checkInChange)
        {
            return new CheckInChangedEvent(checkInChange.ChangeId, checkInChange.PatientId, checkInChange.CheckInStatus, DateTimeOffset.UtcNow.ToUnixTimeSeconds());
        }

        private IEnumerable<CheckInChangedEvent> _events;

        public IOrderedEnumerable<ICheckInEvent> GetEvents(DateTime endDate)
        {
            var unixTimeStamp = new DateTimeOffset(endDate).ToUnixTimeSeconds();
            return _events.Where(e => e.Timestamp <= unixTimeStamp).OrderBy(@event => @event.Timestamp);
        }

        public void Refresh()
        {
            RefreshEventStream();
        }
    }
}