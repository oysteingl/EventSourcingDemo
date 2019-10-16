using System;
using System.Threading.Tasks;
using Domain.Features.CheckIn;
using FluentAssertions;
using InfraStructure.Repositories.CheckIn;
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
}