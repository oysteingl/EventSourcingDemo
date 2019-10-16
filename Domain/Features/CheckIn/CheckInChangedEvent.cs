using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Utilities;

namespace Domain.Features.CheckIn
{
    public class CheckInChangedEvent : ICheckInEvent
    {
        public CheckInChangedEvent(Guid changeId, Guid patientId, CheckInStatus checkInStatus, long timestamp)
        {
            EventId = Guid.NewGuid();
            ChangeId = changeId;
            PatientId = patientId;
            CheckInStatus = checkInStatus;
            Timestamp = timestamp;
        }

        public Guid EventId { get; set; }
        public Guid ChangeId { get; set; }
        public long Timestamp { get; set; }

        public ReadOnlyCollection<PatientWithStatus> Process(ReadOnlyCollection<PatientWithStatus> currentState)
        {
            var ret = new List<PatientWithStatus>();
            ret.AddRange(currentState);

            if (currentState.None(p => p.PatientId.Equals(PatientId)))
            {
                ret.Add(new PatientWithStatus(PatientId, CheckInStatus, Timestamp));
                return ret.AsReadOnly();
            }

            var target = ret.First(p => p.PatientId.Equals(PatientId));
            var updated = new PatientWithStatus(PatientId, CheckInStatus, Timestamp);
            ret.Replace(target, updated);

            return ret.AsReadOnly();
        }

        public Guid PatientId { get; }

        public CheckInStatus CheckInStatus { get; set; }
    }
}