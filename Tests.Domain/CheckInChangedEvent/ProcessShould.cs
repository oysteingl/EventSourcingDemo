using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Domain.Features.CheckIn;
using FluentAssertions;
using Xunit;

namespace Tests.Unit.CheckInChangedEvent
{
    public class ProcessShould
    {

        [Fact]
        public void AddNewCheckedInPatientToState()
        {
            var currentState = new List<PatientWithStatus>().AsReadOnly();
            var patientId = Guid.NewGuid();

            var checkInChangedEvent = new Domain.Features.CheckIn.CheckInChangedEvent(Guid.NewGuid(), patientId, CheckInStatus.CheckedIn);

            var newState = checkInChangedEvent.Process(currentState);

            newState.Should().Contain(p => p.PatientId == patientId);
        }
    }
}