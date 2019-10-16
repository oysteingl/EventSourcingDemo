using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Tests.Repository.CheckInRepository
{
    public class SaveChangeShould
    {
        [Fact]
        public async Task SaveEventToStream()
        {
            var repo = new InMemoryCheckInRepository();
            var patient = new Patient(Guid.NewGuid());
            var change = new CheckInChange (CheckInStatus.CheckedIn, Guid.NewGuid(), patient.PatientId);

            await repo.SaveChange(change);

            var savedEvents = repo.GetEvents();

            savedEvents.Should().Contain(@event => @event.ChangeId == change.ChangeId);
        }
    }

    public class Patient
    {
        public Guid PatientId { get; }

        public Patient(Guid patientId)
        {
            PatientId = patientId;
        }
    }
}