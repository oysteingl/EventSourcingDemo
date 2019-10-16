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
            var change = new CheckInChange{CheckInStatus = CheckInStatus.CheckedIn};

            await repo.SaveChange(change);

            var savedEvents = repo.GetEvents();

            savedEvents.Should().Contain(@event => @event.ChangeId == change.ChangeId);

        }
    }
}