using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Features.CheckIn;

namespace InfraStructure.Repositories
{
    public interface ICheckInRepository
    {
        Task SaveChange(ICheckInChange checkInChange);
        IReadOnlyCollection<ICheckInEvent> GetEvents();
    }
}