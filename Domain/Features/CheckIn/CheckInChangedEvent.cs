using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Utilities;

namespace Domain.Features.CheckIn
{
    public class CheckInChangedEvent : ICheckInEvent
    {
        public CheckInChangedEvent(Guid changeId, Guid patientId, CheckInStatus checkInStatus)
        {
            EventId = Guid.NewGuid();
            ChangeId = changeId;
            PatientId = patientId;
            CheckInStatus = checkInStatus;
        }

        public Guid EventId { get; set; }
        public Guid ChangeId { get; set; }
        
        public ReadOnlyCollection<PatientWithStatus> Process(ReadOnlyCollection<PatientWithStatus> currentState)
        {
            var ret = new List<PatientWithStatus>();
            ret.AddRange(currentState);

            if (currentState.None(p => p.PatientId == PatientId))
            {
                ret.Add(new PatientWithStatus(PatientId, CheckInStatus));
                return ret.AsReadOnly();
            }

            var target = ret.First(p => p.PatientId == PatientId);
            var updated = new PatientWithStatus(PatientId, CheckInStatus);
            ret.Replace(target, updated);

            return ret.AsReadOnly();
        }

        public Guid PatientId { get; }

        public CheckInStatus CheckInStatus { get; set; }
    }
}