using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Domain.Features.CheckIn
{
    public interface ICheckInEvent
    {
        Guid EventId { get; set; }
        Guid ChangeId { get; set; }
        ReadOnlyCollection<PatientWithStatus> Process(ReadOnlyCollection<PatientWithStatus> currentState);
    }
}