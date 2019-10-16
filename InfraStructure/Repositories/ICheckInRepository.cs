using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Features.CheckIn;

namespace InfraStructure.Repositories
{
    public interface ICheckInRepository
    {
        Task SaveChange(ICheckInChange checkInChange);
        IOrderedEnumerable<ICheckInEvent> GetEvents();
    }
}