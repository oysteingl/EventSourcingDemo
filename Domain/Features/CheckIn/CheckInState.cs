using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json.Serialization;
using Utilities;

namespace Domain.Features.CheckIn
{
    public class CheckInState
    {
        public CheckInState(List<PatientWithStatus> patientStatuses)
        {
            PatientStatuses = new ReadOnlyCollection<PatientWithStatus>(patientStatuses);
        }
        public ReadOnlyCollection<PatientWithStatus> PatientStatuses;

        public CheckInState ProcessEvents(IOrderedEnumerable<ICheckInEvent> orderedEvents)
        {
            var currentState = PatientStatuses.Clone();
            foreach (var checkInEvent in orderedEvents)
            {
                currentState = checkInEvent.Process(currentState);
            }
            return new CheckInState(currentState.ToList());
        }
    }

    public class PatientWithStatus
    {
        public Guid PatientId { get; }
        public CheckInStatus CheckInStatus { get; }

        public PatientWithStatus(Guid patientId, CheckInStatus checkInStatus)
        {
            PatientId = patientId;
            CheckInStatus = checkInStatus;
        }
    }
}